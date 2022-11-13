using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;
using Signals;

namespace Controllers
{
    public class StagePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

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
                GameObject temp = PoolSignals.Instance.onGetObject?.Invoke(PoolEnums.Stage);
                temp.transform.position = new Vector3(transform.position.x, transform.position.y + 10);
                temp.SetActive(true);
            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                transform.parent.gameObject.SetActive(false);
            }

        }
    }
}