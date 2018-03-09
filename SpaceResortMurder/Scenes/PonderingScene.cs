using System;
using System.Collections.Generic;
using MonoDragons.Core.Common;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.Pondering;

namespace SpaceResortMurder.Scenes
{
    public class PonderingScene : IScene
    {
        private ClickUI _clickUi;
        private IReadOnlyList<IDilemma> _dilemmas;

        public void Init()
        {
            _clickUi = new ClickUI();
            _dilemmas = GameState.Dilemmas.List;
            _dilemmas.ForEach(x => _clickUi.Add(x.Button));
        }

        public void Update(TimeSpan delta)
        {
            _clickUi.Update(delta);
        }

        public void Draw()
        {
            _dilemmas.ForEach(x => x.Draw());
        }
    }
}
