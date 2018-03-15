using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.CharactersX;
using SpaceResortMurder.Clues;
using SpaceResortMurder.Dialogues;
using SpaceResortMurder.Style;
using SpaceResortMurder.State;
using MonoDragons.Core.EventSystem;
using SpaceResortMurder.ObjectivesX;

namespace SpaceResortMurder.LocationsX
{
    public abstract class LocationScene : IScene
    {
        private readonly Dictionary<Clue, ClickableUIElement> _clues = new Dictionary<Clue, ClickableUIElement>();
        private readonly List<IVisual> _visuals = new List<IVisual>();
        private readonly Location _location;

        private IReadOnlyList<Character> _peopleHere;
        private readonly string _locationImage;
        private IVisual _locationNameLabel;
        private ClickUI _clickUi;
        private ClickUIBranch _tutorialBranch;
        private Reader _reader;
        private ObjectivesView _objectives;
        private Character _talkingTo;
        private ClickUIBranch _investigateRoomBranch;

        private IJamView _subview;
        
        private bool _isPresentingToUser = false;
        private bool _isLoitering = true;

        protected abstract void OnInit();

        protected LocationScene(Location location, string locationImage)
        {
            _location = location;
            _locationImage = locationImage;
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
            if (_isPresentingToUser)
                _reader.Update(delta);
            if (_isLoitering)
                _objectives.Update(delta);

            _clickUi.Update(delta);
            _subview.Update(delta);
        }

        public void Draw()
        {
            UI.FillScreen(_locationImage);

            _visuals.ForEach(x => x.Draw());
            if (_isLoitering)
            {
                _objectives.Draw();
                GameObjects.Hud.Draw();
                _peopleHere.ForEach(p => p.DrawNewIconIfApplicable());
            }

            if (_isPresentingToUser)
                _reader.Draw();
            _subview.Draw();

            UI.FillScreen("UI/ScreenOverlay-Purple");
            _locationNameLabel.Draw();
        }

        private void AutoStartConversationIfApplicable()
        {
            if (_peopleHere.Any(p => p.IsImmediatelyTalking()))
                TalkTo(_peopleHere.First(p => p.IsImmediatelyTalking()));
        }

        private void InitLocation()
        {
            if (!CurrentGameState.HasViewedItem(_location.Value))
                Event.Publish(new ItemViewed(_location.Value));

            CurrentGameState.CurrentLocation = _location.Value;
            CurrentGameState.CurrentLocationImage = _locationImage;
            _location.Clues.ForEach(AddClue);
            _location.Pathways.ForEach(x => AddToRoom(x.CreateButton(ShowCantNavigate)));
            UpdateClues();
        }

        private void InitUiElements()
        {
            _subview = new NoSubView();
            _objectives = new ObjectivesView();
            _objectives.Init();
            _investigateRoomBranch = new ClickUIBranch("Location Investigation", 1);
            _locationNameLabel = UiLabels.HeaderLabel(_location.Name, Color.White);
            _clickUi = new ClickUI();
            _tutorialBranch = new ClickUIBranch("Tutorial", 25);
            _tutorialBranch.Add(_objectives.TutorialButton);
            _clickUi.Add(_tutorialBranch);

            _peopleHere = GameObjects.Characters.GetPeopleAt(_location.Value);
            _peopleHere
                .Select(x => new ImageButton(x.Image, x.Image, x.Image, x.WhereAreYouStanding(),
                    () => TalkTo(x),
                    () => x != _talkingTo))
                .ForEach(AddToRoom);
        }

        private void InitInputs()
        {
            Input.ClearTransientBindings();
            Input.On(Control.Select, () => { if (!_isPresentingToUser) Scene.NavigateTo(GameResources.OptionsSceneName); });
            Input.On(Control.X, () => { if (!_isPresentingToUser) Scene.NavigateTo(GameResources.DilemmasSceneName); });
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
            _talkingTo = character;
            Push(new ConversationView(character, StartLoitering));
        }

        private void Investigate(Clue clue)
        {
            Push(new InvestigateClueView(clue, StartLoitering));
        }

        private void ShowCantNavigate(string pathway)
        {
            StopLoitering();
            _reader = new Reader(new[] { GameResources.GetPathwayText(pathway) }, StartLoitering);
            _isPresentingToUser = true;
        }

        private void Push(IJamView view)
        {
            StopLoitering();
            _subview = view;
            _subview.Init();
            _clickUi.Add(_subview.ClickUiBranch);
        }

        private void StopLoitering()
        {
            _isLoitering = false;
            _clickUi.Clear();
        }

        private void StartLoitering()
        {
            _subview = new NoSubView();
            _clickUi.Clear();
            _isPresentingToUser = false;
            _talkingTo = null;

            UpdateClues();

            _clickUi.Add(_tutorialBranch);
            _clickUi.Add(_investigateRoomBranch);
            _clickUi.Add(GameObjects.Hud.HudBranch);
            _isLoitering = true;
        }

        private void UpdateClues()
        {
            _clues.ForEach(p => p.Value.IsEnabled = p.Key.IsActive());
        }

        public void Dispose()
        {
            _clickUi.Dispose();
        }
    }
}
