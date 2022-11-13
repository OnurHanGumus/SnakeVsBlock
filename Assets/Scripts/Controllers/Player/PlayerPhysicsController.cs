using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        #endregion

        #region Private Variables
        private PlayerManager _manager;



        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _manager = GetComponent<PlayerManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collectable"))
            {
                //StackSignals.Instance.onInteractionCollectable?.Invoke(other.transform.parent.gameObject);
            }
            else if (other.CompareTag("Block"))
            {
                //StackSignals.Instance.onInteractionCube?.Invoke();
                //should wait
            }
        }
    }
}