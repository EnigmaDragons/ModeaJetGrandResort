using Microsoft.Xna.Framework;
using MonoDragons.Core.PhysicsEngine;
using SpaceResortMurder.Dialogs;
using SpaceResortMurder.LocationsX;

namespace SpaceResortMurder.Characters
{
    public class ResortManagerZaid : Person
    {
        public ResortManagerZaid() : base(
            "Zaid, Resort Manager", 
            "Characters/resort_manager_colored", 
            new Size2(300, 705), 
            new DidYouKillHimZaid()) {}

        public override string WhereAreYou()
        {
            return nameof(SecondRoom);
        }

        public override Transform2 WhereAreYouStanding()
        {
            return new Transform2(new Vector2(800, 200), new Size2(200, 470));
        }
    }
}
