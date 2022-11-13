using System.Collections.Generic;
using Data.ValueObject;
using DG.Tweening;
using Keys;
using UnityEngine;

namespace Controllers
{
    public class StackMoveController
    {
        #region Self Variables

        #region Private Veriables

        private StackData _stackData;
        private float _organiserValue = 1;
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

            StackItemsLerpMove(_collectableStack);
        }

        public void StackItemsLerpMove(List<GameObject> _collectableStack)
        {
            for (int i = 1; i < _collectableStack.Count; i++)
            {
                if ((float)_collectableStack[i - 1].transform.position.y - (float)_collectableStack[i].transform.position.y < _stackData.CollectableOffsetInStack)
                {
                    _collectableStack[i].transform.localPosition = new Vector3(Mathf.Lerp(_collectableStack[i].transform.localPosition.x, _collectableStack[i - 1].transform.localPosition.x, _stackData.LerpSpeed_x), _collectableStack[i].transform.localPosition.y);
                    continue;
                }
                else
                {
                    Vector3 pos = _collectableStack[i - 1].transform.localPosition;
                    _collectableStack[i].transform.localPosition = Vector3.Lerp(_collectableStack[i].transform.localPosition, pos, _stackData.LerpSpeed_x); /*new Vector3(Mathf.Lerp(_collectableStack[i].transform.localPosition.x, pos.x, _stackData.LerpSpeed_x), _collectableStack[i - 1].transform.localPosition.y - (_stackData.CollectableOffsetInStack), 0);*/
                }

            }
        }
    }
}