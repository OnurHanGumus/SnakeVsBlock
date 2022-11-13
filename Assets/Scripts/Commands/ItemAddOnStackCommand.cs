using System.Collections.Generic;
using UnityEngine;
using Data.ValueObject;
using Signals;

namespace Commands
{
    public class ItemAddOnStackCommand
    {
        #region Self Variables
        #region Private Variables
        private List<GameObject> _collectableStack;
        private Transform _transform;
        private StackData _stackData;
        #endregion
        #endregion

        public ItemAddOnStackCommand(ref List<GameObject> collectableStack, Transform transform, StackData stackData)
        {
            _collectableStack = collectableStack;
            _transform = transform;
            _stackData = stackData;
        }

        public void Execute(int value)
        {
            for (int i = 0; i < value; i++)
            {
                GameObject temp = PoolSignals.Instance.onGetObject?.Invoke(Enums.PoolEnums.SnakeBody);
                temp.SetActive(true);
                Vector3 newPos = _collectableStack[_collectableStack.Count - 1].transform.localPosition;
                newPos.z -= _stackData.CollectableOffsetInStack;
                temp.transform.localPosition = newPos;
                _collectableStack.Add(temp);
            }

            StackSignals.Instance.onCountChanged?.Invoke(_collectableStack.Count);
        }
    }
}