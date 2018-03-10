using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;

namespace SpaceResortMurder.Pondering
{
    public class WhoKilledRaymondDilemma : Dilemma
    {
        public WhoKilledRaymondDilemma() : base("Who Killed Raymond?", new Transform2(new Vector2(400, 400), new Size2(200, 100))) { }

        public override bool IsActive()
        {
            return true;
        }
    }
}
