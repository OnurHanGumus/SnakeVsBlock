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
    public class PlayerScoreController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private TextMeshPro scoreText;
        #endregion

        #region Private Variables
        private PlayerManager _manager;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _manager = GetComponent<PlayerManager>();
            
        }
        private void Start()
        {
            UpdateText(StackSignals.Instance.onGetStackCount() - 1);
        }
        public void UpdateText(int value)
        {
            scoreText.text = (value - 1).ToString();

        }
    }
}