using System.Linq;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Deductions;
using SpaceResortMurder.State;
using System.Collections.Generic;

namespace SpaceResortMurder.DilemmasX
{
    public abstract class Dilemma
    {
        private readonly string _dilemma;
        private readonly Deduction[] _deductions;
        private readonly Transform2 _transform;
        private ImageBox _newDilemma;
        private ImageBox _newDeductions;

        public bool IsNew => !CurrentGameState.HasViewedItem(_dilemma);
        public bool HasNewAnswers => _deductions.Any(d => d.IsActive() && d.IsNew);
        public bool HasAnswerSelected => _deductions.Any(x => x.IsSelected);

        protected Dilemma(Vector2 position, string dilemma, params Deduction[] deductions)
        {
            _transform = new Transform2(position, new Size2(432, 144));
            _dilemma = dilemma;
            _deductions = deductions;
        }

        public void Init()
        {
            _deductions.ForEach(d => d.Init(ClearPriorDeductions,
                new Transform2(
                    new Vector2(_transform.Location.X, _transform.Location.Y + _transform.Size.Height - 10),
                    new Size2(_transform.Size.Width, 110))));
            _newDilemma = new ImageBox
            {
                Transform = new Transform2(new Vector2(_transform.Location.X + 10, _transform.Location.Y + 10), new Size2(43, 43)),
                Image = "UI/NewRedIconBorderless"
            };
            _newDeductions = new ImageBox
            {
                Transform = new Transform2(new Vector2(_transform.Location.X + _transform.Size.Width - 58, _transform.Location.Y + 7), new Size2(53, 53)),
                Image = "UI/NewDeductionIcon"
            };
        }

        public ImageTextButton CreateButton()
        {
            return new ImageTextButton(_transform.ToRectangle(),
                () =>
                {
                    if (!CurrentGameState.HasViewedItem(_dilemma))
                        Event.Publish(new ItemViewed(_dilemma));
                    Scene.NavigateTo(new DeductionScene(GameResources.GetDilemmaOrDeductionText(_dilemma), _deductions.Where(x => x.IsActive()).ToList()));
                },
                GameResources.GetDilemmaOrDeductionText(_dilemma),
                "UI/DilemmaCard", "UI/DilemmaCard-Hover", "UI/DilemmaCard-Press");
        }

        public abstract bool IsActive();

        public List<IVisual> GetVisuals()
        {
            var visuals = new List<IVisual>();
            if (IsNew)
                visuals.Add(_newDilemma);
            if (HasNewAnswers)
                visuals.Add(_newDeductions);
            visuals.AddRange(_deductions.Where(x => x.IsSelected).Select(x => x.CreateConclusion()));
            return visuals;
        }

        private void ClearPriorDeductions()
        {
            _deductions.ForEach(x => x.Reset());
        }
    }
}