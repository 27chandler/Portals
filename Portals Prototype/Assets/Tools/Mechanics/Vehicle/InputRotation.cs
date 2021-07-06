using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotation : PlayerInput, IControllable
{
    [SerializeField] private float _turnSpeed;
    [Space]
    [SerializeField] private bool _doesMoveInAir = false;
    [SerializeField] private GroundedCheck _groundCheck;

    private bool _areControlsLocked = true;

    void Start()
    {
        if (_doesMoveInAir)
            InputManager.Instance._onMove += Turn;
        else
            InputManager.Instance._onMove += GroundedOnlyTurn;
    }

    private void OnDestroy()
    {
        if (_doesMoveInAir)
            InputManager.Instance._onMove -= Turn;
        else
            InputManager.Instance._onMove -= GroundedOnlyTurn;
    }

    private void GroundedOnlyTurn(Vector2 movement_direction)
    {
        if (_groundCheck._isGrounded)
        {
            Turn(movement_direction);
        }
    }

    private void Turn(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0.0f, movement_direction.x * _turnSpeed * Time.deltaTime, 0.0f));
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
