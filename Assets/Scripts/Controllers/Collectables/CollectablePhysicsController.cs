using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        [SerializeField] private CollectableManager manager;
        #endregion

        #region Private Variables

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
                StackSignals.Instance.onInteractionCollectable?.Invoke(transform.parent.gameObject, manager.Value);
                PlayerSignals.Instance.onPlayerSizeIncreased?.Invoke();
                transform.parent.gameObject.SetActive(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("CollectableDeactivator"))
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }
}