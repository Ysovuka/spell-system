using System;
using System.Collections.Generic;
using System.Text;

namespace System.Spells.Data
{
    public class SpellData
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<EffectData> Effects { get; set; } = new List<EffectData>();
    }
}
