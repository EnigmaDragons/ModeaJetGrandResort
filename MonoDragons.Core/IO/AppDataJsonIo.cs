using System;
using System.IO;
using Newtonsoft.Json;

namespace MonoDragons.Core.IO
{
    public sealed class AppDataJsonIo
    {
        private readonly string _gameStorageFolder;

        public AppDataJsonIo(string gameFolderName)
        {
            _gameStorageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), gameFolderName);
        }

        public T Load<T>(string saveName, string extension = "sav")
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(GetSavePath(saveName, extension)));
        }

        public void Save(string saveName, object data, string extension = "sav")
        {
            if (!Directory.Exists(_gameStorageFolder))
                Directory.CreateDirectory(_gameStorageFolder);
            File.WriteAllText(GetSavePath(saveName, extension), JsonConvert.SerializeObject(data));
        }

        public bool HasSave(string saveName, string extension = "sav")
        {
            return File.Exists(GetSavePath(saveName, extension));
        }

        public void Delete(string saveName, string extension = "sav")
        {
            File.Delete(GetSavePath(saveName, extension));
        }

        private string GetSavePath(string saveName, string extension)
        {
            return Path.Combine(_gameStorageFolder, saveName + "." + extension);
        }
    }
}
