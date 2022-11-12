using System;
using System.Collections.Generic;
using Commands;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using Enums;

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        #region Self Variables
        #region Private Variables

        private LoadGameCommand _loadGameCommand;
        private SaveGameCommand _saveGameCommand;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            _loadGameCommand = new LoadGameCommand();
            _saveGameCommand = new SaveGameCommand();

            SendCollectablesInformation();

        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onSaveCollectables += OnSaveData;
            SaveSignals.Instance.onSaveScore += OnSaveData;
            SaveSignals.Instance.onChangeSoundState += OnSaveData;
            SaveSignals.Instance.onGetScore += OnGetData;

            SaveSignals.Instance.onGetSoundState += OnGetData;

            CoreGameSignals.Instance.onSaveAndResetGameData += OnSaveGameData; //Level ge�i�inde temp savelerin temizlenmesi i�indir.



        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSaveCollectables -= OnSaveData;
            SaveSignals.Instance.onSaveScore -= OnSaveData;
            SaveSignals.Instance.onChangeSoundState -= OnSaveData;

            SaveSignals.Instance.onGetSoundState -= OnGetData;

            CoreGameSignals.Instance.onSaveAndResetGameData -= OnSaveGameData;


        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnSaveListAddElement(int id, SaveLoadStates saveType)
        {
            _saveGameCommand.OnSaveListAddElement(saveType, id);
        }

        private void OnSaveList(List<int> listToSave, SaveLoadStates saveType, SaveFiles fileName)
        {
            _saveGameCommand.OnSaveList(saveType, listToSave, fileName.ToString());
        }

        private void OnSaveData(int value, SaveLoadStates saveType, SaveFiles saveFiles)
        {
            _saveGameCommand.OnSaveData(saveType, value, saveFiles.ToString());

        }

        private void OnSaveGameData() //level ge�i�lerindeki kay�t i�lemidir. Runnderse gold ve gem burada kaydedilir ancak idle oyunsa burada kay�t atmaya gerek yok ��nk� topland��� an kaydedilir. Ge�ici de�erler s�f�rlan�r.
        {
            //_saveGameCommand.OnSaveData(SaveLoadStates.Level, _loadGameCommand.OnLoadGameData(SaveLoadStates.Level) + 1);
            //_saveGameCommand.OnSaveData(SaveLoadStates.Money, _loadGameCommand.OnLoadGameData(SaveLoadStates.Money));
            //_saveGameCommand.OnSaveData(SaveLoadStates.Gem, _loadGameCommand.OnLoadGameData(SaveLoadStates.Gem));


        }


        private void SendCollectablesInformation() //Essential
        {
            //SaveSignals.Instance.onInitializeSetMoney?.Invoke(_loadGameCommand.OnLoadGameData(SaveLoadStates.Money));
            //SaveSignals.Instance.onInitializeSetGem?.Invoke(_loadGameCommand.OnLoadGameData(SaveLoadStates.Gem));
        }

        private int OnGetData(SaveLoadStates state, SaveFiles file)
        {
            return _loadGameCommand.OnLoadGameData(state, file.ToString());

        }
       
    }
}