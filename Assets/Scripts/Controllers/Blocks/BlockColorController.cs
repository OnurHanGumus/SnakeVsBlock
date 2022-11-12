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


        #endregion
        #endregion

        private void Awake()
        {
            Init();
            SetColor(manager.Value);
        }

        private void Init()
        {
            
            _srenderer = GetComponent<SpriteRenderer>();
        }

        public void SetColor(int score)
        {
            color.r = (byte) (score * 5);
            color.g = (byte)(250 - score * 5);
            color.b = (byte)(250 - score * 5);
            color.a = 255;

            _srenderer.color = color;
        }

    }
}