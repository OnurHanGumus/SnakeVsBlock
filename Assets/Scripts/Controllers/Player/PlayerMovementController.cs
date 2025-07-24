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
        private bool _isActive = false, _isInteractedBlock = false;


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
            ClampControl();

            if (_isActive)
            {
                if (_isInteractedBlock)
                {
                    _rig.linearVelocity = new Vector3(_xValue * _data.SpeedHorizontal, 0, 0);
                }
                else
                {
                    _rig.linearVelocity = new Vector3(_xValue * _data.SpeedHorizontal, _data.SpeedVertical, 0);
                }
            }
        }

        private void ClampControl()
        {
            if ((_xValue < 0 && _rig.position.x <= -_data.MaxHorizontalPoint) || (_xValue > 0 && _rig.position.x >= _data.MaxHorizontalPoint))
            {
                _xValue = 0;
            }
        }

        public void OnInputDragged(InputParams param)
        {
            _xValue = param.XValue;
        }

        public float OnGetPlayerSpeed()
        {
            return _data.SpeedHorizontal;
        }
        public void OnPlay()
        {
            _isActive = true;
        }
        public void OnInteractionBlock()
        {
            _isInteractedBlock = true;
            _rig.linearVelocity = Vector2.zero;
        }
        public void OnExitBlock()
        {
            _isInteractedBlock = false;
        }
        public void OnRestartLevel()
        {
            _rig.linearVelocity = Vector3.zero;
            _isActive = false;
            transform.position = Vector3.zero;

        }

        public void OnLevelFailed()
        {
            _isActive = false;
        }

    }
}