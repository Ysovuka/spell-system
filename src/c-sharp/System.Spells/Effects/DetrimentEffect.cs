using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.Spells.Effects
{
    public class DetrimentEffect : Effect
    {
        public override void Apply<TTarget>(TTarget target)
        {
            Debug.WriteLine("Drained target.");
        }
    }
}
