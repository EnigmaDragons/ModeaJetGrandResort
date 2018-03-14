using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Dialogues;
using SpaceResortMurder.Style;
using SpaceResortMurder.State;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.ObjectivesX;
using SpaceResortMurder.Pathways;

namespace SpaceResortMurder.LocationsX
{
    public abstract class LocationScene : IScene
    {
        protected enum Mode
        {
            Loitering,
            InvestigatingClue,
            Conversation,
            Traversing
        }

        private Location _location;

        private ClickUI _clickUI;
        private List<IVisual> _dialogOptions = new List<IVisual>();
        private VisualClickableUIElement _endConversationButton;
        private IVisual _locationNameLabel;
        private ClickUIBranch _characterTalkingToBranch;
        private Character _talkingTo;
        private Clue _investigatingThis;
        private Reader _reader;

        protected Mode CurrentMode { get; private set; } = Mode.Loitering;

        private bool _isInTheMiddleOfDialog = false;
        private bool IsTalking => CurrentMode.Equals(Mode.Conversation);
        private bool IsInvestigatingClue => CurrentMode.Equals(Mode.InvestigatingClue);
        private bool IsLoitering => CurrentMode.Equals(Mode.Loitering);

        private IReadOnlyList<Character> _peopleHere;
        private Dictionary<Clue, ClickableUIElement> _clues = new Dictionary<Clue, ClickableUIElement>();
        private VisualClickableUIElement _scan;
        private ObjectivesView _objectives;
        protected ClickUIBranch _investigateRoomBranch;
        protected List<IVisual> _visuals = new List<IVisual>();

        protected abstract void OnInit();
        protected abstract void DrawBackground();

        protected LocationScene(Location location)
        {
            _location = location;
        }

        public void Init()
        {
            GameObjects.InitIfNeeded();

            InitInputs();
            InitUiElements();
            InitLocation();

            OnInit();

            StartLoitering();
            AutoStartConversationIfApplicable();
        }

        public void Update(TimeSpan delta)
        {
            if (_isInTheMiddleOfDialog)
                _reader.Update(delta);
            if (IsLoitering)
                _objectives.Update(delta);

            _clickUI.Update(delta);
        }

        public void Draw()
        {
            DrawBackground();

            _visuals.ForEach(x => x.Draw());
            if (IsLoitering)
            {
                _objectives.Draw();
                GameObjects.Hud.Draw();
                _peopleHere.ForEach(p => p.DrawNewIconIfApplicable());
            }

            if (IsTalking)
            {
                _talkingTo.DrawTalking();
            }
            if (IsTalking && !_isInTheMiddleOfDialog)
            {
                _scan.Draw();
            }
            if (!_isInTheMiddleOfDialog)
            {
                _dialogOptions.ForEach(x => x.Draw());
                _endConversationButton.Draw();
            }
            if (IsInvestigatingClue)
                _investigatingThis.FacingImage.Draw();
            if (_isInTheMiddleOfDialog)
                _reader.Draw();

            UI.FillScreen("UI/ScreenOverlay-Purple");
            _locationNameLabel.Draw();
        }

        private void AutoStartConversationIfApplicable()
        {
            if (!_peopleHere.Any(p => p.IsImmediatelyTalking()))
                return;

            var person = _peopleHere.First(p => p.IsImmediatelyTalking());
            _clickUI.Remove(_investigateRoomBranch);
            TalkTo(person);
            person.StartImmediatelyTalking(HaveDialog);
        }

        private void InitLocation()
        {
            if (!CurrentGameState.Instance.HasViewedItem(_location.Value))
                Event.Publish(new ItemViewed(_location.Value));

            CurrentGameState.Instance.CurrentLocation = _location.Value;
            _location.Clues.ForEach(AddClue);
            _location.Pathways.ForEach(x => AddToRoom(x.CreateButton(ShowCantNavigate)));
        }

        private void InitUiElements()
        {
            _objectives = new ObjectivesView();
            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);
            _locationNameLabel = UiLabels.HeaderLabel(_location.Name, Color.White);
            _peopleHere = GameObjects.Characters.GetPeopleAt(_location.Value);
            _clickUI = new ClickUI();
            _endConversationButton = new ImageTextButton(new Transform2(new Rectangle(-684, 960, 1380, 77)), StartLoitering,
                "Thanks for your help.",
                "Convo/DialogueButton", "Convo/DialogueButton-Hover", "Convo/DialogueButton-Press", () => IsTalking)
            {
                TextColor = Color.White,
                TextTransform = new Transform2(new Vector2(60, 960), Rotation2.Default, new Size2(1380 - 684, 77), 1.0f),
                TextAlignment = HorizontalAlignment.Left
            };

            _peopleHere
                .Select(x => new ImageButton(x.Image, x.Image, x.Image, x.WhereAreYouStanding(),
                    () => TalkTo(x),
                    () => !(IsTalking && _talkingTo == x)))
                .ForEach(AddToRoom);
            _scan = UiButtons.MenuRed("Scan", new Vector2(816, 1000), () =>
            {
                Event.Publish(new ThoughtGained(_talkingTo.Value));
                HaveDialog(GameResources.GetDialogueLines(_talkingTo.Value));
            });
        }

        private void InitInputs()
        {
            Input.ClearTransientBindings();
            Input.On(Control.Select, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameResources.OptionsSceneName); });
            Input.On(Control.X, () => { if (!_isInTheMiddleOfDialog) Scene.NavigateTo(GameResources.DilemmasSceneName); });
        }

        private void AddClue(Clue clue)
        {
            var button = clue.CreateButton(() => Investigate(clue));
            _clues.Add(clue, button);
            AddToRoom(button);
            button.IsEnabled = clue.IsActive();
        }

        private void AddToRoom(VisualClickableUIElement e)
        {
            _visuals.Add(e);
            _investigateRoomBranch.Add(e);
        }

        private void TalkTo(Character character)
        {
            _clickUI.Remove(_investigateRoomBranch);
            _clickUI.Remove(GameObjects.Hud.HudBranch);

            var drawDialogsOptions = new List<IVisual>();
            _characterTalkingToBranch = new ClickUIBranch("Dialogue Choices", 1);
            var activeDialogs = character.GetNewDialogs();
            activeDialogs.ForEachIndex((x, i) =>
            {
                var button = x.CreateButton(HaveDialog, i, activeDialogs.Count);
                _characterTalkingToBranch.Add(button);
                drawDialogsOptions.Add(button);
            });
            _characterTalkingToBranch.Add(_endConversationButton);
            _characterTalkingToBranch.Add(_scan);
            _dialogOptions = drawDialogsOptions;
            _clickUI.Add(_characterTalkingToBranch);
            _talkingTo = character;
            CurrentMode = Mode.Conversation;
        }

        private void HaveDialog(string[] lines)
        {
            _clickUI.Remove(_characterTalkingToBranch);
            StartReader(lines, EndDialog);
        }

        private void StartReader(string[] lines, Action onFinished)
        {
            _reader = new Reader(lines, onFinished);
            _isInTheMiddleOfDialog = true;
        }

        private void EndDialog()
        {
            _isInTheMiddleOfDialog = false;
            TalkTo(_talkingTo);
        }

        private void Investigate(Clue clue)
        {
            StopLoitering(Mode.InvestigatingClue);
            StartReader(clue.InvestigationLines, StartLoitering);
            _investigatingThis = clue;
        }

        private void ShowCantNavigate(string pathway)
        {
            StopLoitering(Mode.Traversing);
            StartReader(new[] { GameResources.GetPathwayText(pathway) }, StartLoitering);
        }

        private void StopLoitering(Mode newMode)
        {
            _clickUI.Remove(_investigateRoomBranch);
            _clickUI.Remove(GameObjects.Hud.HudBranch);
            CurrentMode = newMode;
        }

        private void StartLoitering()
        {
            _clickUI.Clear();

            _clickUI.Add(_investigateRoomBranch);
            _clickUI.Add(GameObjects.Hud.HudBranch);

            _dialogOptions = new List<IVisual>();
            _isInTheMiddleOfDialog = false;

            UpdateClues();

            CurrentMode = Mode.Loitering;
        }

        private void UpdateClues()
        {
            _clues.ForEach(p => p.Value.IsEnabled = p.Key.IsActive());
        }

        public void Dispose()
        {
            _clickUI.Dispose();
        }
    }
}
