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

    public int _number = 1;

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
        SetRandomNumber();
    }
    private void Start()
    {
        SetRandomNumber();

    }

    private void SetRandomNumber()
    {
        Value = Random.Range(1, 16);
    }
}