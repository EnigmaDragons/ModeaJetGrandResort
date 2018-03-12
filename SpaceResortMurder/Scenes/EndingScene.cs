﻿using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using MonoDragons.Core.Scenes;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.ResolutionsX;
using SpaceResortMurder.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceResortMurder.Scenes
{
    public class EndingScene : JamScene
    {
        protected override void OnInit()
        {
            Add(UiButtons.Menu("Credits", new Vector2(780, 800), () => Scene.NavigateTo(GameResources.CreditsSceneName)));
            AddVisual(new Label() { TextColor = Color.White, BackgroundColor = Color.Black,
                Transform = new Transform2(new Vector2(210, 100), new Size2(1500, 600)),
                Text = "Zaid was executed for killing Raymond, " + (GameState.Instance.IsThinking(nameof(IAmLeaving)) ? "and you left.": "and you stayed.")
            });
        }

        protected override void DrawBackground()
        {
        }

        protected override void DrawForeground()
        {
        }
    }
}