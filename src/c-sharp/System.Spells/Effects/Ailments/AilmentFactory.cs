using System;
using System.Collections.Generic;
using System.Text;

namespace System.Spells.Effects.Ailments
{
    public static class AilmentFactory
    {
        private static readonly IDictionary<string, Type> _dictionary
            = new Dictionary<string, Type>();

        static AilmentFactory()
        {
            Add("Blind", typeof(BlindAilment));
        }

        public static void Add(string descriptor, Type effectType)
        {
            if (!_dictionary.ContainsKey(descriptor.ToLower()))
            {
                _dictionary.Add(descriptor.ToLower(), effectType);
            }
        }

        public static AilmentEffect Parse(string descriptor)
        {
            if (_dictionary.ContainsKey(descriptor.ToLower()))
            {
                return (AilmentEffect)Activator.CreateInstance(_dictionary[descriptor.ToLower()]);
            }
            else
            {
                throw new NotImplementedException("The effect supplied is not currently supported.");
            }
        }

        public static bool TryParse(string descriptor, out AilmentEffect effect)
        {
            try
            {
                effect = Parse(descriptor);
                return true;
            }
            catch (NotImplementedException)
            {
                effect = null;
                return false;
            }
        }
    }
}
