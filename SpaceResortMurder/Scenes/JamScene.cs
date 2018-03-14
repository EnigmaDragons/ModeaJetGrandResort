using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.TutorialsX;
using System;
using System.Collections.Generic;

namespace SpaceResortMurder.Scenes
{
    public abstract class JamScene : IScene
    {
        private readonly List<IVisual> _visuals = new List<IVisual>();
        private readonly List<IAutomaton> _automata = new List<IAutomaton>();

        private ClickUI _clickUi;
        private ClickUIBranch _tutorialBranch;

        protected abstract void OnInit();
        protected abstract void DrawBackground();
        protected abstract void DrawForeground();

        public void Init()
        {
            GameObjects.InitIfNeeded();
            Input.ClearTransientBindings();
            _clickUi = new ClickUI();
            _tutorialBranch = new ClickUIBranch("Tutorial", 10);
            _clickUi.Add(_tutorialBranch);
            _automata.Add(_clickUi);
            OnInit();
        }

        public void Update(TimeSpan delta)
        {
            _automata.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            DrawBackground();
            _visuals.ForEach(x => x.Draw(Transform2.Zero));
            DrawForeground();
        }

        protected void AddVisual(IVisual v)
        {
            _visuals.Add(v);
        }

        protected void Add(Tutorial t)
        {
            _visuals.Add(t);
            _tutorialBranch.Add(t.Button);
            _automata.Add(t);
        }

        protected void AddUi(ClickableUIElement e)
        {
            _clickUi.Add(e);
        }

        protected void Add(VisualClickableUIElement e)
        {
            _clickUi.Add(e);
            _visuals.Add(e);
        }

        protected void Add(IVisualAutomaton v)
        {
            _automata.Add(v);
            _visuals.Add(v);
        }

        protected void Add(IAutomaton a)
        {
            _automata.Add(a);
        }

        protected void Add(IVisual v)
        {
            _visuals.Add(v);
        }

        public void Dispose()
        {
            _clickUi.Dispose();
        }
    }
}