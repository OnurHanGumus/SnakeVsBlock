using System;

namespace Data.ValueObject
{
    [Serializable]
    public class BlockData
    {
        public float BreakTime = 0.1f;
        public int ValueMin = 1, ValueMax = 50;
    }
}