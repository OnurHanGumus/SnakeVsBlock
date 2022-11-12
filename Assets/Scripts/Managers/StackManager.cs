using System;
using System.Collections.Generic;
using Controllers;
using UnityEngine;
using Signals;
using Data.UnityObject;
using Data.ValueObject;
using Commands;
using DG.Tweening;
using Enums;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        public List<GameObject> CollectableStack = new List<GameObject>();
        public ItemAddOnStackCommand ItemAddOnStack;

        #endregion

        #region Seralized Veriables
        [SerializeField] private GameObject levelHolder;
        #endregion

        #region Private Variables

        private StackData _stackData;
        private StackMoveController _stackMoveController;

        private GameObject _playerGameObject;
        private bool _isActive = false;

        #endregion
        #endregion

        private void Awake()
        {
            Init();


        }

        private StackData GetStackData() => Resources.Load<CD_Stack>("Data/CD_Stack").Data;

        private void Init()
        {
            _stackData = GetStackData();

            _stackMoveController = new StackMoveController();
            _stackMoveController.InisializedController(_stackData);
            ItemAddOnStack = new ItemAddOnStackCommand(ref CollectableStack, transform, _stackData);

            //_itemRemoveOnStackCommand = new ItemRemoveOnStackCommand(ref CollectableStack, ref levelHolder);
            //_randomRemoveListItemCommand = new RandomRemoveListItemCommand(ref CollectableStack, ref levelHolder);
            //_stackShackAnimCommand = new StackShackAnimCommand(ref CollectableStack, _stackData);
            //_setColorState = new SetColorState(ref CollectableStack);
            //_dublicateStateItemsCommand = new DublicateStateItemsCommand(ref CollectableStack, ref ItemAddOnStack);
            //_stackItemBorder = new StackItemBorder(ref UnstackList);
            //_unstackItemsToStack = new UnstackItemsToStack(ref CollectableStack, ref UnstackList, ref _dublicateStateItemsCommand, gameObject);
        }

        #region Event Subscription
        private void OnEnable()
        {
            SubscribeEvent();
            //_initialzeStackCommand.Execute(_stackData.InitialStackItem);
        }

        private void SubscribeEvent()
        {
            //CoreGameSignals.Instance.onReset += OnReset;
            StackSignals.Instance.onInteractionCollectable += OnInteractionWithCollectable;
            //StackSignals.Instance.onInteractionObstacle += _itemRemoveOnStackCommand.Execute;
            PlayerSignals.Instance.onSetPlayer += OnSetPlayer;
            CoreGameSignals.Instance.onPlay += OnPlay;
            //DronePoolSignals.Instance.onGetStackCount += OnGetStackCount;
            //LevelSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        }
        private void UnSubscribeEvent()
        {
            //CoreGameSignals.Instance.onReset -= OnReset;
            StackSignals.Instance.onInteractionCollectable -= OnInteractionWithCollectable;
            //StackSignals.Instance.onInteractionObstacle -= _itemRemoveOnStackCommand.Execute;
            PlayerSignals.Instance.onSetPlayer -= OnSetPlayer;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            //DronePoolSignals.Instance.onGetStackCount -= OnGetStackCount;
            //LevelSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        }
        private void OnDisable()
        {
            UnSubscribeEvent();
        }
        #endregion

        private void Start()
        {
            ItemAddOnStack.Execute(_stackData.InitializeStackAmount);
        }

        private void Update()
        {
            StackMove();
        }

        private void OnSetPlayer(GameObject player)
        {
            _playerGameObject = player;
        }

        private void StackMove()
        {
            if (_isActive)
            {
                _stackMoveController.StackItemsMoveOrigin(_playerGameObject.transform.position, CollectableStack);
            }

        }

        private void OnInteractionWithCollectable(GameObject collectableGameObject, int value)
        {
            ItemAddOnStack.Execute(value);
            collectableGameObject.tag = "Collected";
        }



        //private void OnReset()
        //{
        //    foreach (Transform childs in transform)
        //    {
        //        Destroy(childs.gameObject);
        //    }
        //    CollectableStack.Clear();
        //    _initialzeStackCommand.Execute(_stackData.InitialStackItem);
        //}


        private int OnGetStackCount()
        {
            return CollectableStack.Count;
        }

        private void OnLevelSuccessful()
        {
           
        }

        private void OnPlay()
        {
            _isActive = true;
        }
    }
}