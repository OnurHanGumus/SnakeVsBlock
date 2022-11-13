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
        CreateCollectables(Random.Range(2, 8));
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
        CreateCollectables(10);
    }

    private void CreateCollectables(int yPos)
    {
        GameObject tmp = PoolSignals.Instance.onGetObject(PoolEnums.Collectable);
        tmp.SetActive(true);
        tmp.transform.position = new Vector3(Random.Range(-2, 3), _playerTransform.position.y + yPos);
    }


}