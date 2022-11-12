using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

namespace Controllers
{
    public class StackMoveController
    {
        #region Self Variables

        #region Private Veriables

        private StackData _stackData;
        #endregion
        #endregion

        public void InisializedController(StackData Stackdata)
        {
            _stackData = Stackdata;
        }

        public void StackItemsMoveOrigin(Vector3 direction, List<GameObject> _collectableStack)
        {
            if (_collectableStack.Count <= 0)
            {
                return;
            }

            float directx = Mathf.Lerp(_collectableStack[0].transform.localPosition.x, direction.x, _stackData.LerpSpeed_x);

            _collectableStack[0].transform.localPosition = new Vector3(directx, _collectableStack[0].transform.localPosition.y, 0);
            StackItemsLerpMove(_collectableStack);
        }

        public void StackItemsLerpMove(List<GameObject> _collectableStack)
        {
            for (int i = 1; i < _collectableStack.Count; i++)
            {
                Vector3 pos = _collectableStack[i - 1].transform.localPosition;
                _collectableStack[i].transform.localPosition = new Vector3(
                    Mathf.Lerp(_collectableStack[i].transform.localPosition.x, pos.x, _stackData.LerpSpeed_x), _collectableStack[i - 1].transform.localPosition.y - (_stackData.CollectableOffsetInStack), 0);
            }
        }
    }
}