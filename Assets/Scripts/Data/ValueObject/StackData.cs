using System;

namespace Data.ValueObject
{
    [Serializable]
    public class StackData
    {
        public float CollectableOffsetInStack = 1;

        public float LerpSpeed_x = 0.25f;

        public float ShackAnimDuraction = 0.12f;
        public float ShackScaleValue = 1f;

        public int InitialStackItem = 5;

        public float DistanceFormPlayer = -1f;
    }
}