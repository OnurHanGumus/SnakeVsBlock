using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Keys;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectableCreateManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables


    #endregion
    #region Serializefield Variables


    #endregion
    #region Private Variables
    private Transform _playerTransform;

    #endregion
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
    }
    private void Start()
    {
        _playerTransform = PlayerSignals.Instance.onGetPlayer().transform;
        OnCreateCollectable();

    }

    private void OnEnable()
    {
        SubscribeEvents();
    }


    private void SubscribeEvents()
    {
        PlayerSignals.Instance.onPlayerSizeIncreased += OnCreateCollectable;

    }

    private void UnsubscribeEvents()
    {
        PlayerSignals.Instance.onPlayerSizeIncreased -= OnCreateCollectable;


    }
    private void OnDisable()
    {
        UnsubscribeEvents();
    }
    private void OnCreateCollectable()
    {
        GameObject tmp = PoolSignals.Instance.onGetCollectableFromPool();
        tmp.SetActive(true);
        tmp.transform.position = new Vector3(Random.Range(-2,3), _playerTransform.position.y + 10);
    }


}