using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using Keys;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        #endregion

        #region Private Variables
        private Rigidbody2D _rig;
        private PlayerManager _manager;
        private float _xValue;
        private PlayerData _data;


        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _rig = GetComponent<Rigidbody2D>();
            _manager = GetComponent<PlayerManager>();
            _data = _manager.GetData();
        }


        private void FixedUpdate()
        {
            _rig.velocity = new Vector3(_xValue * _data.SpeedHorizontal, _data.SpeedHorizontal, 0);
        }

        public void OnInputDragged(InputParams param)
        {
            _xValue = param.XValue;
        }

        public float OnGetPlayerSpeed()
        {
            return _data.SpeedHorizontal;
        }
    }
}