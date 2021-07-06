using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleWheelTurn : PlayerInput, IControllable
{
    [SerializeField] private float _turnAngle;

    private bool _areControlsLocked = true;

    [SerializeField] private Transform _leftWheel;
    [SerializeField] private Transform _rightWheel;

    void Start()
    {
        InputManager.Instance._onMove += Turn;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Turn;
    }

    private void Turn(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            _leftWheel.localRotation = Quaternion.Euler(_leftWheel.localRotation.x, movement_direction.x * _turnAngle, _leftWheel.localRotation.z);
            _rightWheel.localRotation = Quaternion.Euler(_rightWheel.localRotation.x, movement_direction.x * _turnAngle, _rightWheel.localRotation.z);
        }
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
