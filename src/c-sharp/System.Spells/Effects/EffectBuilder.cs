using System;
using System.Collections.Generic;
using System.Spells.Data;
using System.Spells.Effects.Ailments;
using System.Text;

namespace System.Spells.Effects
{
    public static class EffectBuilder
    {
        private static readonly IDictionary<string, Func<EffectData, Effect>> _dictionary
            = new Dictionary<string, Func<EffectData, Effect>>();

        static EffectBuilder()
        {
            Add("Ailment", BuildAilmentEffect);
            Add("Detriment", BuildGenericEffect<DetrimentEffect>);
            Add("Enchantment", BuildGenericEffect<EnchantmentEffect>);
        }

        public static void Add(string descriptor, Func<EffectData, Effect> buildFunc)
        {
            if (!_dictionary.ContainsKey(descriptor.ToLower()))
            {
                _dictionary.Add(descriptor, buildFunc);
            }
            else
            {
                _dictionary[descriptor.ToLower()] = buildFunc;
            }
        }

        public static Func<EffectData, Effect> Parse(string descriptor)
        {
            if (_dictionary.ContainsKey(descriptor))
            {
                return _dictionary[descriptor];
            }
            else
            {
                throw new NotImplementedException("The specified builder is not currently implemented.");
            }
        }

        public static bool TryParse(string descriptor, out Func<EffectData, Effect> buildFunc)
        {
            try
            {
                buildFunc = Parse(descriptor);
                return true;
            }
            catch (NotImplementedException)
            {
                buildFunc = null;
                return false;
            }
        }

        public static Effect Build(EffectData data)
        {
            if (TryParse(data.Nature, out Func<EffectData, Effect> buildFunc))
            {
                return buildFunc(data);
            }
            else
            {
                return null;
            }
        }

        private static Effect BuildAilmentEffect(EffectData data)
        {
            Effect effect = AilmentFactory.Parse(data.Ailment)
                .ApplyBaseEffectData(data);

            if (string.IsNullOrEmpty(data.ImmunityDuration))
            {
                return effect;
            }
            else
            {
                return effect.AsAilment()
                    .WithImmunization(data.ImmunityDuration);
            }
        }

        private static Effect BuildGenericEffect<T>(EffectData data)
            where T : Effect
        {
            Effect effect = Activator.CreateInstance<T>();
            return effect.ApplyBaseEffectData(data);
        }

        private static Effect ApplyBaseEffectData(this Effect effect, EffectData data)
        {
            return effect.WithName(data.Name)
                .WithDescription(data.Description)
                .WithDomain(data.Domain);
        }
    }
}
