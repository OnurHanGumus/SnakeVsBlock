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
    [SerializeField] private GameObject stagePrefab;
    [SerializeField] private GameObject snakeBodyPrefab;



    [SerializeField] private List<GameObject> collectablePool;
    [SerializeField] private List<GameObject> stagePool;
    [SerializeField] private List<GameObject> snakeBodyPool;




    [SerializeField] private int amountCollectables = 50;
    [SerializeField] private int amountStages = 3;
    [SerializeField] private int amountSnakeBodys = 30;



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
        InitializeCollectablePool();
        InitializeStagePool();
        InitializeSnakeBodyPool();
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
        PoolSignals.Instance.onGetCollectableFromPool += OnGetCollectable;
        PoolSignals.Instance.onGetStageFromPool += OnGetStage;
        PoolSignals.Instance.onGetSnakeBodyFromPool += OnGetSnakeBody;



        PoolSignals.Instance.onGetPoolManagerObj += OnGetPoolManagerObj;


        //PlayerSignals.Instance.onPlayerSelectGun += OnPlayerSelectGun;
        CoreGameSignals.Instance.onRestartLevel += OnReset;

    }

    private void UnsubscribeEvents()
    {
        PoolSignals.Instance.onGetCollectableFromPool -= OnGetCollectable;
        PoolSignals.Instance.onGetStageFromPool -= OnGetStage;
        PoolSignals.Instance.onGetSnakeBodyFromPool -= OnGetSnakeBody;


        PoolSignals.Instance.onGetPoolManagerObj -= OnGetPoolManagerObj;


        //PlayerSignals.Instance.onPlayerSelectGun -= OnPlayerSelectGun;
        CoreGameSignals.Instance.onRestartLevel -= OnReset;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion


    private void InitializeCollectablePool()
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

    private void InitializeStagePool()
    {
        stagePool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountStages; i++)
        {
            tmp = Instantiate(stagePrefab, transform);
            tmp.SetActive(false);
            stagePool.Add(tmp);
        }
    }

    private void InitializeSnakeBodyPool()
    {
        snakeBodyPool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountSnakeBodys; i++)
        {
            tmp = Instantiate(snakeBodyPrefab, transform);
            tmp.SetActive(false);
            snakeBodyPool.Add(tmp);
        }
    }

    public GameObject OnGetCollectable()
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

    public GameObject OnGetStage()
    {
        for (int i = 0; i < amountStages; i++)
        {
            if (!stagePool[i].activeInHierarchy)
            {
                return stagePool[i];
            }
        }
        return null;
    }


    public GameObject OnGetSnakeBody()
    {
        for (int i = 0; i < amountSnakeBodys; i++)
        {
            if (!snakeBodyPool[i].activeInHierarchy)
            {
                return snakeBodyPool[i];
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
        foreach (var i in stagePool)
        {
            i.transform.position = new Vector3(0, 6.88f, 0);
        }
    }
}
