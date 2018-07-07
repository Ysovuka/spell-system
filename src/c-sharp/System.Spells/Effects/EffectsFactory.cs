using System;
using System.Collections.Generic;
using System.Text;

namespace System.Spells.Effects
{
    public static class EffectsFactory
    {
        private static readonly IDictionary<string, Type> _dictionary
            = new Dictionary<string, Type>();

        static EffectsFactory()
        {
            Add("Enchantment", typeof(EnchantmentEffect));
            Add("Detriment", typeof(DetrimentEffect));
            Add("Ailment", typeof(AilmentEffect));
        }

        public static void Add(string descriptor, Type effectType)
        {
            if (!_dictionary.ContainsKey(descriptor.ToLower()))
            {
                _dictionary.Add(descriptor.ToLower(), effectType);
            }
        }

        public static Effect Parse(string descriptor)
        {
            if (_dictionary.ContainsKey(descriptor.ToLower()))
            {
                return (Effect)Activator.CreateInstance(_dictionary[descriptor.ToLower()]);
            }
            else
            {
                throw new NotImplementedException("The effect supplied is not currently supported.");
            }
        }

        public static bool TryParse(string descriptor, out Effect effect)
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
