using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Spells.Data;
using System.Spells.Effects;
using System.Text;

namespace System.Spells
{
    public class Spell
    {
        public Spell() { }

        public static Spell Create() => new Spell();

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Effect> Effects { get; private set; } = new List<Effect>();

        public void Apply<TCaster, TTarget>(TCaster caster, TTarget target)
        {
            foreach(var effect in Effects)
            {
                effect.Apply(target);
            }
        }

        public static Spell Create(string fileData)
        {
            SpellData data = JsonConvert.DeserializeObject<SpellData>(fileData);

            Spell spell = new Spell()
                .WithName(data.Name)
                .WithDescription(data.Description);

            foreach(var effect in data.Effects)
            {
                spell.WithEffect(EffectBuilder.Build(effect));               
            }

            return spell;
        }
    }
}
