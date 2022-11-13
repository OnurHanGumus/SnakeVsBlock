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
using Random = UnityEngine.Random;

public class BlockManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion
    #region Serializefield Variables
    [SerializeField] private BlockColorController colorController;

    #endregion
    #region Private Variables
    private int _number;
    private BlockScoreController _blockScoreController;
    private BlockData _data;

    #endregion
    #region Properties
    [ShowInInspector]
    public int Value
    {
        get { return _number; }
        set
        {
            _number = value;
            _blockScoreController.UpdateText(Value);
            colorController.SetColor(Value);
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
        _data = GetBlockData();
        _blockScoreController = GetComponent<BlockScoreController>();
    }
    public BlockColorData GetColorData() => Resources.Load<CD_BlockColor>("Data/CD_BlockColor").Data;
    public BlockData GetBlockData() => Resources.Load<CD_BlockData>("Data/CD_BlockData").Data;
    #region Event Subcription
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void Start()
    {
        SetRandomNumber();

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
        SetRandomNumber();
    }
    #endregion

    private void SetRandomNumber()
    {
        Value = Random.Range(_data.ValueMin, _data.ValueMax);
    }
}