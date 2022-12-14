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
    private PlayerScoreController _scoreController;

    #endregion
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _movementController = GetComponent<PlayerMovementController>();
        _scoreController = GetComponent<PlayerScoreController>();
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
        CoreGameSignals.Instance.onRestartLevel += _movementController.OnRestartLevel;
        CoreGameSignals.Instance.onLevelFailed += _movementController.OnLevelFailed;
        StackSignals.Instance.onInteractionCube += _movementController.OnInteractionBlock;
        BlockSignals.Instance.onBlockBreaked += _movementController.OnExitBlock;
        BlockSignals.Instance.onPlayerExitBlock += _movementController.OnExitBlock;
        StackSignals.Instance.onCountChanged += _scoreController.UpdateText;

        PlayerSignals.Instance.onGetPlayer += OnGetPlayer;

    }

    private void UnsubscribeEvents()
    {
        InputSignals.Instance.onInputDragged -= _movementController.OnInputDragged;
        CoreGameSignals.Instance.onPlay -= _movementController.OnPlay;
        CoreGameSignals.Instance.onRestartLevel -= _movementController.OnRestartLevel;
        CoreGameSignals.Instance.onLevelFailed -= _movementController.OnLevelFailed;
        StackSignals.Instance.onInteractionCube -= _movementController.OnInteractionBlock;
        BlockSignals.Instance.onBlockBreaked -= _movementController.OnExitBlock;
        BlockSignals.Instance.onPlayerExitBlock -= _movementController.OnExitBlock;
        StackSignals.Instance.onCountChanged -= _scoreController.UpdateText;

        PlayerSignals.Instance.onGetPlayer -= OnGetPlayer;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private GameObject OnGetPlayer()
    {
        return gameObject;
    }


}