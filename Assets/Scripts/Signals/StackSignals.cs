using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class StackSignals : MonoSingleton<StackSignals>
    {
        public UnityAction<GameObject,int> onInteractionCollectable = delegate { };
        public UnityAction onInteractionCube = delegate { };
        public UnityAction<int> onCountChanged= delegate { };

        public Func<int> onGetStackCount = delegate { return 0; };
    }
}