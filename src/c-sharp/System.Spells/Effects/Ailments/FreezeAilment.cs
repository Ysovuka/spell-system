﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.Spells.Effects.Ailments
{
    public class FreezeAilment : AilmentEffect
    {
        public override void Apply<TTarget>(TTarget target)
        {
            Debug.WriteLine("Freezes target.");
        }
    }
}
