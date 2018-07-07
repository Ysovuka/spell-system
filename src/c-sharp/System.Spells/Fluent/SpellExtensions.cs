using System;
using System.Collections.Generic;
using System.Spells.Effects;
using System.Text;

namespace System.Spells
{
    public static class SpellExtensions
    {
        public static Spell WithName(this Spell spell, string name)
        {
            spell.Name = name;
            return spell;
        }

        public static Spell WithDescription(this Spell spell, string description)
        {
            spell.Description = description;
            return spell;
        }

        public static Spell WithEffect(this Spell spell, Effect effect)
        {
            effect.Spell = spell;
            spell.Effects.Add(effect);
            return spell;
        }
    }
}
