
namespace SpaceResortMurder.State
{
    public sealed class Options
    {
        public bool IsFullscreen { get; set; } = false;
        public float Scale { get; set; } = 1;
        public float MusicVolume { get; set; } = 0.8f;
        public float SoundVolume { get; set; } = 0.8f;
        public double MillisPerTextCharacter { get; set; } = 40d;
        public bool TutorialsEnabled { get; set; } = true;
    }
}
