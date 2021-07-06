using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerMovement : PlayerInput, IControllable
{
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private bool _areControlsLocked = true;
    [SerializeField] private float _movementSpeed, _jumpStrength;
    [Space]
    [SerializeField] private GroundedCheck _groundCheck;

    void Start()
    {
        InputManager.Instance._onJump += Jump;
        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onJump -= Jump;
        InputManager.Instance._onMove -= Move;
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked && !freezeInput)
        {
            // The change in position this frame
            Vector3 position_delta = new Vector3();
            position_delta += (transform.right * Input.GetAxis("Horizontal")) * _movementSpeed * Time.deltaTime;
            position_delta += (transform.forward * Input.GetAxis("Vertical")) * _movementSpeed * Time.deltaTime;

            _playerRb.MovePosition(_playerRb.position + position_delta);
        }
    }

    private void Jump()
    {
        if (!_areControlsLocked && _groundCheck._isGrounded && !freezeInput)
            _playerRb.AddForce(transform.up * _jumpStrength);
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
