using System;

namespace Data.ValueObject
{
    [Serializable]
    public class BlockData
    {
        public float BreakTime = 0.1f;
        public int ValueMin = 1, ValueMax = 50;

        public BlockDataSize[] Sizes = { new BlockDataSize() { ValueMin = 1, ValueMax = 5 }, new BlockDataSize() { ValueMin = 1, ValueMax = 15 }, new BlockDataSize() { ValueMin = 16, ValueMax = 30 }, new BlockDataSize() { ValueMin = 31, ValueMax = 50 }};
    }
    [Serializable]
    public class BlockDataSize
    {
        public int ValueMin = 1, ValueMax = 50;

    }
}