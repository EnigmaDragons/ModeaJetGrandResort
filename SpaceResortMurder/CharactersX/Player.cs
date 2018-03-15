using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;
using MonoDragons.Core.PhysicsEngine;
using Microsoft.Xna.Framework;

namespace SpaceResortMurder.CharactersX
{
    public class Player
    {
        private Dictionary<Expression, IVisual> Images = new Dictionary<Expression, IVisual>()
        {
            {
                Expression.Default,
                new ImageBox
                {
                    Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.2f), UI.OfScreenHeight(1.0f) - (int)(1200 / 1.3)), new Size2(490, 1200)),
                    Image = "characters/main_character"
                }
            },
            {
                Expression.Angry,
                new ImageBox
                {
                    Transform = new Transform2(new Vector2(UI.OfScreenWidth(0.2f), UI.OfScreenHeight(1.0f) - (int)(1200 / 1.3)), new Size2(490, 1200)),
                    Image = "characters/main_character_angry"
                }
            },
        };

        public IVisual GetImage(Expression expression = Expression.Default)
        {
            return Images[expression];
        }
    }
}
