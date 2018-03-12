﻿using MonoDragons.Core.AudioSystem;
using MonoDragons.Core.UserInterface;
using SpaceResortMurder.State;

namespace SpaceResortMurder.LocationsX
{
    public class LobbyScene : LocationScene
    {
        public LobbyScene() : base(nameof(Lobby)) {}

        protected override string Name => "Hotel Lobby";

        protected override void OnInit()
        {
            Audio.PlayMusicOnce("HotelLobby", Options.Instance.MusicVolume);
        }

        protected override void DrawBackground()
        {
            UI.FillScreen("Locations/hotel_lobby_environment");
        }
    }
}
