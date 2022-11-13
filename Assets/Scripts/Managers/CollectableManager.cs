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

public class CollectableManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion
    #region Serializefield Variables

    [SerializeField] private CollectableScoreController scoreController;
    #endregion
    #region Private Variables

    private int _number = 1;
    private CollectableData _data;


    #endregion
    #region Properties Variables
    public int Value
    {
        get { return _number; }
        set
        {
            _number = value;
            scoreController.UpdateText(Value);
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
        _data = GetData();
    }
    public CollectableData GetData() => Resources.Load<CD_Collectable>("Data/CD_Collectable").Data;

    #region Event Subcription
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
        SetRandomNumber();
    }
    #endregion
    private void Start()
    {
        SetRandomNumber();

    }

    private void SetRandomNumber()
    {
        Value = Random.Range(_data.MinValue, _data.MaxValue);
    }
}