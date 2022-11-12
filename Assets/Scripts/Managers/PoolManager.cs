using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Signals;
using Enums;

public class PoolManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private GameObject collectablePrefab;



    [SerializeField] private List<GameObject> collectablePool;




    [SerializeField] private int amountCollectables = 50;



    #endregion
    #region Private Variables
    private int _levelId = 0;
    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _levelId = LevelSignals.Instance.onGetCurrentModdedLevel();
        InitializeEnemyPool();

        //InitializeBulletPool();
    }

    

    #region Event Subscriptions
    void Start()
    {

    }
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PoolSignals.Instance.onGetCollectableFromPool += OnGetEnemy;



        PoolSignals.Instance.onGetPoolManagerObj += OnGetPoolManagerObj;


        //PlayerSignals.Instance.onPlayerSelectGun += OnPlayerSelectGun;

    }

    private void UnsubscribeEvents()
    {
        PoolSignals.Instance.onGetCollectableFromPool -= OnGetEnemy;


        PoolSignals.Instance.onGetPoolManagerObj -= OnGetPoolManagerObj;


        //PlayerSignals.Instance.onPlayerSelectGun -= OnPlayerSelectGun;


    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion


    private void InitializeEnemyPool()
    {
        collectablePool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountCollectables; i++)
        {
            tmp = Instantiate(collectablePrefab, transform);
            tmp.SetActive(false);
            collectablePool.Add(tmp);
        }
    }

    public GameObject OnGetEnemy()
    {
        for (int i = 0; i < amountCollectables; i++)
        {
            if (!collectablePool[i].activeInHierarchy)
            {
                return collectablePool[i];
            }
        }
        return null;
    }

    public Transform OnGetPoolManagerObj()
    {
        return transform;
    }


    private void OnReset()
    {
        //reset
    }


}
