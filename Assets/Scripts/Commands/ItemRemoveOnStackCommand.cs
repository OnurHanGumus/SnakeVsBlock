using System.Collections.Generic;
using Managers;
using Signals;
using UnityEngine;

namespace Commands
{
    public class ItemRemoveOnStackCommand
    {
        #region Self Variables
        #region Private Variables
        private List<GameObject> _collectableStack;
        #endregion
        #endregion

        public ItemRemoveOnStackCommand(ref List<GameObject> CollectableStack)
        {
            _collectableStack = CollectableStack;
        }
        public void Execute()
        {
            int index = _collectableStack.Count - 1;
            _collectableStack[index].SetActive(false);
            _collectableStack.RemoveAt(index);
            _collectableStack.TrimExcess();
            Debug.Log("asdasd");
            //ScoreSignals.Instance.onSetScore?.Invoke(_collectableStack.Count);

        }
    }
}