using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.IO;
using MonoDragons.Core.Memory;
using MonoDragons.Core.Scenes;
using SpaceResortMurder.State;

namespace SpaceResortMurder.SavesX
{
    public class SaveSlot
    {
        private static readonly AppDataJsonIo Io = GameObjects.IO;

        private string _fileName;

        public bool HasSave { get; private set; }
        public string PlayerName { get; private set; } = "";
        public string CoverImage { get; private set; } = "Images/None";

        public static SaveSlot Create(int slot)
        {
            var s = new SaveSlot();
            s.Init("Save " + slot);
            return s;
        }

        private void Init(string fileName)
        {
            _fileName = fileName;
            HasSave = GameObjects.IO.HasSave(_fileName);
            if (HasSave)
            {
                var state = Io.Load<GameState>(_fileName);
                try
                {
                    Resources.Load<Texture2D>(state.CurrentLocationImage);
                    PlayerName = state.PlayerName;
                    CoverImage = state.CurrentLocationImage;
                }
                catch
                {
                    HasSave = false;
                    Io.Delete(_fileName);
                }
            }
        }

        public void Execute(SaveMode mode)
        {
            if (mode.Equals(SaveMode.Save))
                SaveTo();
            if (mode.Equals(SaveMode.Load))
                Load();
            if (mode.Equals(SaveMode.Delete))
                Delete();
        }

        public void SaveTo()
        {
            GameObjects.IO.Save(_fileName, CurrentGameState.Value);
            Scene.NavigateTo(CurrentGameState.CurrentLocation);
        }

        public void Load()
        {
            CurrentGameState.Load(_fileName);
            Scene.NavigateTo(GameResources.LoadingSceneName);
        }

        public void Delete()
        {
            Io.Delete(_fileName);
            Init(_fileName);
        }
    }
}
