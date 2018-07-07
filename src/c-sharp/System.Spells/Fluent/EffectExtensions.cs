using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Spells.Effects;
using System.Text;

namespace System.Spells
{
    public static class EffectExtensions
    {
        #region Effect Extensions
        public static AilmentEffect AsAilment(this Effect effect)
        {
            return (AilmentEffect)effect;
        }

        public static Effect WithName(this Effect effect, string name)
        {
            effect.Name = name;
            return effect;
        }

        public static Effect WithDescription(this Effect effect, string description)
        {
            effect.Description = description;
            return effect;
        }

        public static Effect WithDomain(this Effect effect, string domain)
        {
            effect.Domain = domain;
            return effect;
        }

        #endregion Effect Extensions


        #region AilmentEffect Extensions

        public static AilmentEffect WithImmunization(this AilmentEffect effect, string duration)
        {
            try
            {
                string[] formats = new string[]
                {
                    @"%d\d",
                    @"%h\h",
                    @"%m\m",
                    @"%s\s",

                    @"f\m\s",
                    @"ff\m\s",
                    @"fff\m\s",
                };

                foreach (string segment in duration.Split(' '))
                {
                    int value = 0;
                    if (segment.EndsWith("ms"))
                    {
                        value = int.Parse(segment.Substring(0, segment.IndexOf("ms")));
                        effect.ImmunityDuration += TimeSpan.FromMilliseconds(value);
                    }
                    else
                    {
                        value = int.Parse(segment.Substring(0, segment.Length - 1));

                        switch (segment[segment.Length - 1])
                        {
                            case 'd':
                                effect.ImmunityDuration += TimeSpan.FromDays(value);
                                break;
                            case 'h':
                                effect.ImmunityDuration += TimeSpan.FromHours(value);
                                break;
                            case 'm':
                                effect.ImmunityDuration += TimeSpan.FromMinutes(value);
                                break;
                            case 's':
                                effect.ImmunityDuration += TimeSpan.FromSeconds(value);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            return effect;
        }

        #endregion AilmentEffect Extensions


        public static Spell Parent<T>(this T effect)
            where T : Effect
        {
            return effect.Spell;
        }
    }
}
