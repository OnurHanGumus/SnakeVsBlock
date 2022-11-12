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
        public List<GameObject> UnstackList = new List<GameObject>();
        //public ItemAddOnStackCommand ItemAddOnStack;

        #endregion

        #region Seralized Veriables
        [SerializeField] private GameObject levelHolder;
        //[SerializeField] private GameObject collectable;
        #endregion

        #region Private Variables

        private StackData _stackData;
        private StackMoveController _stackMoveController;
        //private ItemRemoveOnStackCommand _itemRemoveOnStackCommand;
        //private RandomRemoveListItemCommand _randomRemoveListItemCommand;
        //private StackShackAnimCommand _stackShackAnimCommand;
        //private InitialzeStackCommand _initialzeStackCommand;
        //private DublicateStateItemsCommand _dublicateStateItemsCommand;
        //private StackItemBorder _stackItemBorder;
        private GameObject _playerGameObject;
        //private SetColorState _setColorState;
        //private Transform _poolTriggerTransform;
        //private UnstackItemsToStack _unstackItemsToStack;

        private Vector3 _direction;

        #endregion
        #endregion

        private void Awake()
        {
            _stackData = GetStackData();
            Init();
        }

        private StackData GetStackData() => Resources.Load<CD_Stack>("Data/CD_Stack").Data;

        private void Init()
        {
            _stackMoveController = new StackMoveController();
            //_stackMoveController.InisializedController(_stackData);
            //ItemAddOnStack = new ItemAddOnStackCommand(ref CollectableStack, transform, _stackData);
            //_itemRemoveOnStackCommand = new ItemRemoveOnStackCommand(ref CollectableStack, ref levelHolder);
            //_randomRemoveListItemCommand = new RandomRemoveListItemCommand(ref CollectableStack, ref levelHolder);
            //_stackShackAnimCommand = new StackShackAnimCommand(ref CollectableStack, _stackData);
            //_initialzeStackCommand = new InitialzeStackCommand(collectable, this);
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
            //StackSignals.Instance.onInteractionCollectable += OnInteractionWithCollectable;
            //StackSignals.Instance.onInteractionObstacle += _itemRemoveOnStackCommand.Execute;
            //StackSignals.Instance.onPlayerGameObject += OnSetPlayer;
            //StackSignals.Instance.ColorType += OnGateState;
            //GunPoolSignals.Instance.onWrongGunPool += _randomRemoveListItemCommand.Execute;
            //GunPoolSignals.Instance.onGunPoolExit += _dublicateStateItemsCommand.Execute;
            //DronePoolSignals.Instance.onPlayerCollideWithDronePool += OnPlayerCollideWithDronePool;
            //DronePoolSignals.Instance.onCollectableCollideWithDronePool += OnStackToUnstack;
            //DronePoolSignals.Instance.onWrongDronePool += OnWrongDronePoolCollectablesDelete;
            //DronePoolSignals.Instance.onDroneGone += OnDroneGone;
            //DronePoolSignals.Instance.onGetStackCount += OnGetStackCount;
            //StackSignals.Instance.onGetCurrentScore += OnGetStackCount;
            //LevelSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        }
        private void UnSubscribeEvent()
        {
            //CoreGameSignals.Instance.onReset -= OnReset;
            //StackSignals.Instance.onInteractionCollectable -= OnInteractionWithCollectable;
            //StackSignals.Instance.onInteractionObstacle -= _itemRemoveOnStackCommand.Execute;
            //StackSignals.Instance.onPlayerGameObject -= OnSetPlayer;
            //StackSignals.Instance.ColorType -= OnGateState;
            //GunPoolSignals.Instance.onWrongGunPool -= _randomRemoveListItemCommand.Execute;
            //GunPoolSignals.Instance.onGunPoolExit -= _dublicateStateItemsCommand.Execute;
            //DronePoolSignals.Instance.onPlayerCollideWithDronePool -= OnPlayerCollideWithDronePool;
            //DronePoolSignals.Instance.onCollectableCollideWithDronePool -= OnStackToUnstack;
            //DronePoolSignals.Instance.onWrongDronePool -= OnWrongDronePoolCollectablesDelete;
            //DronePoolSignals.Instance.onDroneGone -= OnDroneGone;
            //DronePoolSignals.Instance.onGetStackCount -= OnGetStackCount;
            //StackSignals.Instance.onGetCurrentScore -= OnGetStackCount;
            //DronePoolSignals.Instance.onOutlineBorder -= _stackItemBorder.Execute;
            //LevelSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        }
        private void OnDisable()
        {
            UnSubscribeEvent();
        }
        #endregion

        private void Start()
        {
            //ScoreSignals.Instance.onSetScore?.Invoke(CollectableStack.Count);
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
            if (gameObject.transform.childCount > 0)
            {
                _stackMoveController.StackItemsMoveOrigin(_playerGameObject.transform.position, CollectableStack);
            }
        }

        //private void OnInteractionWithCollectable(GameObject collectableGameObject)
        //{
        //    ItemAddOnStack.Execute(collectableGameObject);
        //    collectableGameObject.tag = "Collected";
        //    StartCoroutine(_stackShackAnimCommand.Execute());
        //}



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
    }
}