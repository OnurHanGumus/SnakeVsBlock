using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Keys;
using Signals;
using UnityEngine;
using Sirenix.OdinInspector;

public class BlockManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    


    #endregion
    #region Serializefield Variables


    #endregion
    #region Private Variables
    private int _number = 5;

    private BlockScoreController _blockScoreController;
    #endregion
    #region Properties
    [ShowInInspector]
    public int Value
    {
        get { return _number; }
        set
        {
            _number = value;
            _blockScoreController.UpdateText(_number);
        }
    }
    #endregion
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _blockScoreController = GetComponent<BlockScoreController>();
    }
    public PlayerData GetData() => Resources.Load<CD_Player>("Data/CD_Player").Data;

    private void OnEnable()
    {
        SubscribeEvents();
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

    private void Start()
    {

    }
}