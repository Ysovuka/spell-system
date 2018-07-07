using System;
using System.Collections.Generic;
using System.Text;

namespace System.Spells.Effects.Ailments
{
    public class FaintAilment : AilmentEffect
    {
        public override void Apply<TTarget>(TTarget target)
        {
            Debug.WriteLine("Target faints.");
        }
    }
}
