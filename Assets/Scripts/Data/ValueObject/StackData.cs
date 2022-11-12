using System;

namespace Data.ValueObject
{
    [Serializable]
    public class StackData
    {
        public float CollectableOffsetInStack = 1;

        public float LerpSpeed_x = 0.25f;
        public int InitializeStackAmount = 4;
    }
}