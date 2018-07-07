using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Spells.Data;
using System.Spells.Effects;
using System.Spells.Effects.Ailments;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Spells.Test
{
    public class BasicTests
    {
        [Fact]
        public async Task HealSpellFromData()
        {
            string fileContents = "{}";
            using (StreamReader reader = new StreamReader(File.Open("basic-heal.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                fileContents = await reader.ReadToEndAsync();
            }

            
            Spell spell = Spell.Create(fileContents);

            Assert.Equal(1, spell.Effects.Count);
            Assert.NotNull(spell.Effects.FirstOrDefault(e => e.GetType() == typeof(EnchantmentEffect)));
        }

        [Fact]
        public async Task DrainSpellFromData()
        {
            string fileContents = "{}";
            using (StreamReader reader = new StreamReader(File.Open("basic-drain.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                fileContents = await reader.ReadToEndAsync();
            }

            Spell spell = Spell.Create(fileContents);

            Assert.Equal(1, spell.Effects.Count);
            Assert.NotNull(spell.Effects.FirstOrDefault(e => e.GetType() == typeof(DetrimentEffect)));
        }

        [Fact]
        public async Task BlindSpellFromData()
        {
            string fileContents = "{}";
            using (StreamReader reader = new StreamReader(File.Open("Ailments/blind.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
            {
                fileContents = await reader.ReadToEndAsync();
            }

            Spell spell = Spell.Create(fileContents);

            Assert.Equal(1, spell.Effects.Count);
            Assert.NotNull(spell.Effects.FirstOrDefault(e => e.GetType() == typeof(BlindAilment)));

            AilmentEffect blindEffect = (AilmentEffect)spell.Effects.FirstOrDefault(e => e.GetType() == typeof(BlindAilment));
            Assert.Equal(TimeSpan.FromSeconds(5), blindEffect.ImmunityDuration);
        }
    }
}
