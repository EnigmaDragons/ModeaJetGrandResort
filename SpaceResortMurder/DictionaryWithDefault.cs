using System.Collections.Generic;

namespace SpaceResortMurder
{
    public class DictionaryWithDefault<T1, T2> : Dictionary<T1, T2>
    {
        private readonly T2 _defaultValue;

        public DictionaryWithDefault(T2 defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public new T2 this[T1 key]
        {
            get => ContainsKey(key) ? base[key] : _defaultValue;
            set => base[key] = value;
        }
    }
}
