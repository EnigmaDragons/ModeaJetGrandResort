﻿using MonoDragons.Core.Common;

namespace SpaceResortMurder.State
{
    public sealed class Options
    {
        public bool IsFullscreen { get; set; } = false;
        public float Scale { get; set; } = 1;
        public float MusicVolume { get; set; } = 0.5f;
        public float SoundVolume { get; set; } = 0.5f;
        public double MillisPerTextCharacter { get; set; } = 40d;
        public bool TutorialsEnabled { get; set; } = true;
        public int FakeLoadMilliseconds { get; set; } = Rng.Int(2500, 3500);
    }
}
