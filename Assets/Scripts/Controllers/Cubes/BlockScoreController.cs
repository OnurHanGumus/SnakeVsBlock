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
    public class BlockScoreController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private TextMeshPro scoreText;
        #endregion

        #region Private Variables
        private BlockManager _manager;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _manager = GetComponent<BlockManager>();
            scoreText.text = _manager.Value.ToString();
        }
        public void UpdateText(int value)
        {
            scoreText.text = value.ToString();
        }
    }
}