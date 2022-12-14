using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;
using System.Collections;
using Data.UnityObject;

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
        private BlockData _data;
        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = manager.GetBlockData();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _targetValue = StackSignals.Instance.onGetStackCount();
                StartCoroutine(StartReduce());
            }
            else if (other.CompareTag("Block") || other.CompareTag("Collectable"))
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
            else if (other.CompareTag("CollectableDeactivator"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
 

        private IEnumerator StartReduce()
        {
            StackSignals.Instance.onInteractionCube?.Invoke();
            ScoreSignals.Instance.onScoreIncrease?.Invoke(ScoreTypeEnums.Score, 1);
            if (--manager.Value <= 0)
            {
                BlockSignals.Instance.onBlockBreaked?.Invoke();
                PlayParticle();
                StopAllCoroutines();
                transform.parent.gameObject.SetActive(false);
            }
            if (--_targetValue <= 0)
            {
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(_data.BreakTime);

            StartCoroutine(StartReduce());
        }

        private void PlayParticle()
        {
            GameObject temp = PoolSignals.Instance.onGetObject(PoolEnums.Particle);
            temp.transform.position = transform.position;
            temp.SetActive(true);
        }
    }
}