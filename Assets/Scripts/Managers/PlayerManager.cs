using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Keys;
using Signals;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables


    #endregion
    #region Serializefield Variables


    #endregion
    #region Private Variables
    private PlayerMovementController _movementController;

    #endregion
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _movementController = GetComponent<PlayerMovementController>();

    }
    public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

    private void OnEnable()
    {
        SubscribeEvents();
    }


    private void SubscribeEvents()
    {
        InputSignals.Instance.onInputDragged += _movementController.OnInputDragged;
        CoreGameSignals.Instance.onPlay += _movementController.OnPlay;
        StackSignals.Instance.onInteractionCube += _movementController.OnInteractionBlock;
        BlockSignals.Instance.onBlockBreaked += _movementController.OnExitBlock;
        BlockSignals.Instance.onPlayerExitBlock += _movementController.OnExitBlock;
    }

    private void UnsubscribeEvents()
    {
        InputSignals.Instance.onInputDragged -= _movementController.OnInputDragged;
        CoreGameSignals.Instance.onPlay -= _movementController.OnPlay;
        StackSignals.Instance.onInteractionCube -= _movementController.OnInteractionBlock;
        BlockSignals.Instance.onBlockBreaked -= _movementController.OnExitBlock;
        BlockSignals.Instance.onPlayerExitBlock -= _movementController.OnExitBlock;


    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Start()
    {
        PlayerSignals.Instance.onSetPlayer?.Invoke(gameObject);

    }
}