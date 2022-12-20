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

        private int _levelID;
        private LevelData _data;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _levelID = GetActiveLevel();
            _data = GetData();
        }

        private int GetActiveLevel()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("Level") ? ES3.Load<int>("Level") : 0;
        }
        private LevelData GetData() => Resources.Load<CD_Level>("Data/CD_Level").Data;

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
            InitializeCollectables();
            InitializeBlocks();
            InitializeSticks();
        }

        private void InitializeStage()
        {
            GameObject temp = PoolSignals.Instance.onGetObject?.Invoke(PoolEnums.Stage);
            temp.transform.position = new Vector3(transform.position.x, (_levelID + 1) * _data.HeightBtwLevels);
            temp.SetActive(true);
        }

        private void InitializeCollectables()
        {
            GameObject temp;
            int tempInt = Random.Range(_data.MinCollectableCount, _data.MaxCollectableCount);
            for (int i = 0; i < tempInt; i++)
            {
                temp = PoolSignals.Instance.onGetObject(PoolEnums.Collectable);
                temp.SetActive(true);
                temp.transform.position = new Vector3(Random.Range(_data.CollectableMinXAxisPos, _data.CollectableMaxXAxisPos), (_levelID + 1) * _data.HeightBtwLevels + Random.Range(_data.CollectableMinYAxisPos, _data.CollectableMaxYAxisPos));
            }
        }

        private void InitializeBlocks()
        {
            GameObject temp;
            int tempInt = Random.Range(_data.MinBlockCount, _data.MaxBlockCount);
            tempInt = Random.Range(_data.MinBlockCount, _data.MaxBlockCount);
            for (int i = 0; i < tempInt; i++)
            {
                temp = PoolSignals.Instance.onGetObject(PoolEnums.Blocks);
                temp.SetActive(true);
                temp.transform.position = new Vector3(Random.Range(_data.BlockMinXAxisPos, _data.BlockMaxXAxisPos), (_levelID + 1) * _data.HeightBtwLevels + Random.Range(_data.BlockMinYAxisPos, _data.BlockMaxYAxisPos));
            }
        }

        private void InitializeSticks()
        {
            GameObject temp;
            int tempInt = Random.Range(_data.MinStickCount, _data.MaxStickCount);
            for (int i = 0; i < tempInt; i++)
            {
                temp = PoolSignals.Instance.onGetObject(PoolEnums.Stick);
                temp.SetActive(true);
                temp.transform.position = new Vector3(Random.Range((int)(_data.StickMinXAxisPos * _data.StickXAxisMultiplier),(int)(_data.StickMaxXAxisPos * _data.StickXAxisMultiplier)) + _data.StickXOffset, (_levelID + 1) * _data.HeightBtwLevels + Random.Range(_data.StickMinYAxisPos, _data.StickMaxYAxisPos));
            }
        }


        private void OnClearActiveLevel()
        {
            levelClearer.ClearActiveLevel(levelHolder.transform);
        }
    }
}