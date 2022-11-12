using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Extentions;
using Keys;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using Enums;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables


        #endregion

        #region Private Variables
        private int _money = 0;
        private int _gem = 0;

        [ShowInInspector]
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;

            }
        }
        [ShowInInspector]
        public int Gem
        {
            get { return _gem; }
            set { _gem = value; }
        }

        private int _score;
        [ShowInInspector]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }


        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {

        }
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease += OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease += OnScoreDecrease;

            ScoreSignals.Instance.onGetScore += OnGetScore;


        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease -= OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease -= OnScoreDecrease;

            ScoreSignals.Instance.onGetScore -= OnGetScore;


        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnScoreIncrease(ScoreTypeEnums type, int amount)
        {
            //if (type.Equals(ScoreTypeEnums.Money))
            //{
            //    _money += amount;
            //    UISignals.Instance.onSetChangedText?.Invoke(type, _money);
            //    SaveSignals.Instance.onSaveCollectables?.Invoke(_money, SaveLoadStates.Money, SaveFiles.SaveFile);

            //}
            //else
            //{
            //    _gem += amount;
            //    UISignals.Instance.onSetChangedText?.Invoke(type, _gem);
            //    SaveSignals.Instance.onSaveCollectables?.Invoke(_gem, SaveLoadStates.Gem, SaveFiles.SaveFile);
            //}
        }

        private void OnScoreDecrease(ScoreTypeEnums type, int amount)
        {
            //if (type.Equals(ScoreTypeEnums.Money))
            //{
            //    _money -= amount;
            //    UISignals.Instance.onSetChangedText?.Invoke(type, _money);
            //    SaveSignals.Instance.onSaveCollectables?.Invoke(_money, SaveLoadStates.Money, SaveFiles.SaveFile);

            //}
            //else
            //{
            //    _gem -= amount;
            //    UISignals.Instance.onSetChangedText?.Invoke(type, _gem);
            //    SaveSignals.Instance.onSaveCollectables?.Invoke(_gem, SaveLoadStates.Gem, SaveFiles.SaveFile);
            //}
        }


        private int OnGetScore()
        {
            return Score;
        }
    }
}