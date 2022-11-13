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
        #endregion

        #region Private Variables

        private StackData _stackData;
        private StackMoveController _stackMoveController;
        private ItemRemoveOnStackCommand _itemRemoveOnStackCommand;


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
            _playerGameObject = PlayerSignals.Instance.onGetPlayer();
            CollectableStack.Add(_playerGameObject);
            _stackData = GetStackData();
            _stackMoveController = new StackMoveController();
            _stackMoveController.InisializedController(_stackData);
            ItemAddOnStack = new ItemAddOnStackCommand(ref CollectableStack, transform, _stackData);
            _itemRemoveOnStackCommand = new ItemRemoveOnStackCommand(ref CollectableStack);
        }

        #region Event Subscription
        private void OnEnable()
        {
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            StackSignals.Instance.onInteractionCollectable += OnInteractionWithCollectable;
            StackSignals.Instance.onInteractionCube += _itemRemoveOnStackCommand.Execute;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
            StackSignals.Instance.onGetStackCount += OnGetStackCount;
        }
        private void UnSubscribeEvent()
        {
            StackSignals.Instance.onInteractionCollectable -= OnInteractionWithCollectable;
            StackSignals.Instance.onInteractionCube -= _itemRemoveOnStackCommand.Execute;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
            StackSignals.Instance.onGetStackCount -= OnGetStackCount;
        }
        private void OnDisable()
        {
            UnSubscribeEvent();
        }
        #endregion


        private void Update()
        {
            StackMove();
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

        private void InitializeStack()
        {
            ItemAddOnStack.Execute(_stackData.InitializeStackAmount);
        }

        private void Start()
        {
            InitializeStack();
        }
        private int OnGetStackCount()
        {
            return CollectableStack.Count;
        }

        private void OnPlay()
        {
            _isActive = true;
        }

        private void OnRestartLevel()
        {
            for (int i = 1; i < CollectableStack.Count; i++)
            {
                CollectableStack[i].SetActive(false);
            }

            CollectableStack.Clear();
            CollectableStack.Add(_playerGameObject);
            InitializeStack();
        }
    }
}