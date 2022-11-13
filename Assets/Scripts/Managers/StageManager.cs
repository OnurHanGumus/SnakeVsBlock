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
    public class StageManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables
        [SerializeField] private List<GameObject> childs;

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

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {


        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion


        private void ActivateChildrens()
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].SetActive(true);
            }
        }
    }
}