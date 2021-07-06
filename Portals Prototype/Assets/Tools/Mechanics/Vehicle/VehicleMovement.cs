using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : PlayerInput, IControllable
{
    [SerializeField] private float _acceleration;

    [SerializeField] private Rigidbody _carRb;
    [Space]
    [SerializeField] private bool _doesMoveInAir = false;
    [SerializeField] private GroundedCheck _groundCheck;

    private bool _areControlsLocked = true;

    void Start()
    {
        _carRb.transform.parent = null;

        if (_doesMoveInAir)
            InputManager.Instance._onMove += Move;
        else
            InputManager.Instance._onMove += GroundedOnlyMove;
    }

    private void OnDestroy()
    {
        if (_doesMoveInAir)
            InputManager.Instance._onMove -= Move;
        else
            InputManager.Instance._onMove -= GroundedOnlyMove;
    }

    private void FixedUpdate()
    {
        transform.position = _carRb.transform.position;
    }

    private void GroundedOnlyMove(Vector2 movement_direction)
    {
        if (_groundCheck._isGrounded)
            Move(movement_direction);
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            _carRb.AddForce(transform.forward * movement_direction.y * _acceleration * Time.deltaTime);
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
