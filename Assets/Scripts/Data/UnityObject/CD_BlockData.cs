using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BlockData", menuName = "Picker3D/CD_BlockData", order = 0)]
    public class CD_BlockData : ScriptableObject
    {
        public BlockData Data;
    }
}