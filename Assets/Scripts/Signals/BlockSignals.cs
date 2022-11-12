using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Signals
{
    public class BlockSignals : MonoSingleton<BlockSignals>
    {
        public UnityAction onBlockBreaked = delegate { };
        public UnityAction onPlayerExitBlock = delegate { };

    }
}