using System;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public int HeightBtwLevels = 10;

        public int MinCollectableCount = 1, MaxCollectableCount = 5;
        public float BlockMinXAxisPos = -2.3f, BlockMaxXAxisPos = 2.3f;
        public float BlockMinYAxisPos = 1f, BlockMaxYAxisPos = 9f;

        public int MinBlockCount = 0, MaxBlockCount = 3;
        public int CollectableMinXAxisPos = -2, CollectableMaxXAxisPos = 3;
        public int CollectableMinYAxisPos = 1, CollectableMaxYAxisPos = 9;
    }
}