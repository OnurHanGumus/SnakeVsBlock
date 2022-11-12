using System;

namespace Data.ValueObject
{
    [Serializable]
    public class BlockColorData
    {
        public float Multiplier = 16;
        public int[] ColorRanks = { 16, 33, 50 };
    }
}