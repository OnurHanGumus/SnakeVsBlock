using System;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Keys;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables

        [Space] [SerializeField] private GameObject levelHolder;
        [SerializeField] private LevelLoaderCommand levelLoader;
        [SerializeField] private ClearActiveLevelCommand levelClearer;

        #endregion

        #region Private Variables

        [ShowInInspector] private int _levelID;

        #endregion

        #endregion

        private void Awake()
        {
            _levelID = GetActiveLevel();
        }

        private int GetActiveLevel()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("Level") ? ES3.Load<int>("Level") : 0;
        }


        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnInitializeLevel;
            CoreGameSignals.Instance.onClearActiveLevel += OnClearActiveLevel;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
            CoreGameSignals.Instance.onGetLevelID += OnGetLevelID;
            CoreGameSignals.Instance.onPlay += OnPlay;

        }



        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnInitializeLevel;
            CoreGameSignals.Instance.onClearActiveLevel -= OnClearActiveLevel;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
            CoreGameSignals.Instance.onGetLevelID -= OnGetLevelID;
            CoreGameSignals.Instance.onPlay -= OnPlay;

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {
            OnInitializeLevel();
        }

        private void OnNextLevel()
        {
            _levelID++;
            OnInitializeLevel();
        }

        private void OnRestartLevel()
        {
            _levelID = 0;
        }

        private int OnGetLevelID()
        {
            return _levelID;
        }


        private void OnInitializeLevel()
        {
            InitializeStage();
        }

        private void InitializeStage()
        {

            GameObject temp = PoolSignals.Instance.onGetObject?.Invoke(PoolEnums.Stage);
            temp.transform.position = new Vector3(transform.position.x, (_levelID + 1) * 10);
            temp.SetActive(true);

            int tempInt = Random.Range(1, 5);
            for (int i = 0; i < tempInt; i++)
            {
                temp = PoolSignals.Instance.onGetObject(PoolEnums.Collectable);
                temp.SetActive(true);
                temp.transform.position = new Vector3(Random.Range(-2.3f, 2.3f), (_levelID + 1) * 10 + Random.Range(1f, 9f));
            }

            tempInt = Random.Range(0, 3);
            for (int i = 0; i < tempInt; i++)
            {
                temp = PoolSignals.Instance.onGetObject(PoolEnums.Blocks);
                temp.SetActive(true);
                temp.transform.position = new Vector3(Random.Range(-2, 3), (_levelID + 1) * 10 + Random.Range(1, 9));
            }

        }

        
        private void OnClearActiveLevel()
        {
            levelClearer.ClearActiveLevel(levelHolder.transform);
        }
    }
}