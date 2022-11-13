using System;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public int HeightBtwLevels = 10;

        public int MinBlockCount = 0, MaxBlockCount = 3;
        public int BlockMinXAxisPos = -2, BlockMaxXAxisPos = 3;
        public int BlockMinYAxisPos = 1, BlockMaxYAxisPos = 9;

        public int MinCollectableCount = 1, MaxCollectableCount = 5;
        public float CollectableMinXAxisPos = -2.3f, CollectableMaxXAxisPos = 2.3f;
        public float CollectableMinYAxisPos = 1f, CollectableMaxYAxisPos = 9f;
    }
}