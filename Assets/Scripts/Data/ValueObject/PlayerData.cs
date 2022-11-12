using System;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public float SpeedHorizontal = 2f;
        public float SpeedVertical = 2f;

        public float MaxHorizontalPoint = 2.38f;
    }
}