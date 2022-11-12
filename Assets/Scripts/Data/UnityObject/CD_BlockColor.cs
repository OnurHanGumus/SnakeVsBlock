using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BlockColor", menuName = "Picker3D/CD_BlockColor", order = 0)]
    public class CD_BlockColor : ScriptableObject
    {
        public BlockColorData Data;
    }
}