using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;
using System.Collections;

namespace Controllers
{
    public class BlockPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private BlockManager manager;

        #endregion

        #region Private Variables
        private int _targetValue = 0;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _targetValue = StackSignals.Instance.onGetStackCount();
                StartCoroutine(StartReduce());
            }
            else if (other.CompareTag("Block"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                BlockSignals.Instance.onPlayerExitBlock?.Invoke();
                StopAllCoroutines();
            }
        }

        private IEnumerator StartReduce()
        {
            StackSignals.Instance.onInteractionCube?.Invoke();
            if (--manager.Value <= 0)
            {
                BlockSignals.Instance.onBlockBreaked?.Invoke();
                StopAllCoroutines();
            }
            if (--_targetValue <= 0)
            {
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.1f);

            StartCoroutine(StartReduce());
        }
    }
}