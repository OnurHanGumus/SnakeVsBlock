using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Extentions;
using Keys;
using Signals;
using UnityEngine;
using Enums;
using Random = UnityEngine.Random;

namespace Managers
{
    public class StageManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables
        [SerializeField] private List<BlockManager> childs;

        #endregion

        #region Private Variables


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
            ActivateChildrens();

        }

        private void Start()
        {

        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {


        }

        private void OnDisable()
        {
            UnsubscribeEvents();
            SetRandomLowNumberedBlock();

        }

        #endregion


        private void ActivateChildrens()
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].gameObject.SetActive(true);
            }
        }

        private void SetRandomLowNumberedBlock()
        {
            int temp = Random.Range(0, childs.Count);
            childs[temp].SetAsLowNumberedBlock();
        }
    }
}