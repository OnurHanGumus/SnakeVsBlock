using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;
using System.Collections;
using TMPro;

namespace Controllers
{
    public class BlockColorController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private Color32 color;
        [SerializeField] private BlockManager manager;

        #endregion

        #region Private Variables
        private SpriteRenderer _srenderer;
        public BlockColorData _data;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Start()
        {
            SetColor(manager.Value);
        }

        private void Init()
        {
            _srenderer = GetComponent<SpriteRenderer>();
            _data = manager.GetColorData();
        }

        public void SetColor(int score)
        {
            if (score < _data.ColorRanks[0])
            {
                color.r = 0;
                color.g = 255;
                color.b = (byte)(Mathf.Abs(255 - (score * _data.Multiplier)));
            }
            else if (score < _data.ColorRanks[1])
            {
                color.r = (byte)(Mathf.Abs(score - 17) * _data.Multiplier);
                color.g = 255;
                color.b = 0;
            }
            else if (score < _data.ColorRanks[2])
            {
                color.r = 255;
                color.g = (byte)(255 - (Mathf.Abs(score - 34) * _data.Multiplier));
                color.b = 0;
            }

            color.a = 255;

            _srenderer.color = color;
        }

    }
}