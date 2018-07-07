using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.Spells.Effects
{
    public abstract class AilmentEffect : Effect
    {
        public TimeSpan ImmunityDuration { get; set; }
    }
}
