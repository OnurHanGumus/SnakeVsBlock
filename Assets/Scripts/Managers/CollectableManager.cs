using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Keys;
using Signals;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    public int Value = 1;

    #endregion
    #region Serializefield Variables


    #endregion
    #region Private Variables
   

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
    }

    private void Start()
    {

    }
}