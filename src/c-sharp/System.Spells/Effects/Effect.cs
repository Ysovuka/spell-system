using System;
using System.Collections.Generic;
using System.Text;

namespace System.Spells.Effects
{
    public abstract class Effect
    {
        public Spell Spell { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }

        public abstract void Apply<TTarget>(TTarget target);
    }
}
