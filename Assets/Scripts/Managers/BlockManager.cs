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
        _blockScoreController = GetComponent<BlockScoreController>();
    }
    public BlockColorData GetData() => Resources.Load<CD_BlockColor>("Data/CD_BlockColor").Data;

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



    private void SetRandomNumber()
    {
        Value = Random.Range(1, 50);
    }
}