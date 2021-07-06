using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : PlayerInput, IControllable
{
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private CharacterController _controller;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpheight = 3.0f;
    [SerializeField] private bool _areControlsLocked = false;

    private Vector3 _velocity;
    private bool _isGrounded;


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

    void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded)
        {
            Collider[] ground_colliders = Physics.OverlapSphere(_groundCheck.position, _groundDistance, _groundMask);
            Rigidbody ground_rb = ground_colliders[0].GetComponent<Rigidbody>();

            if (ground_rb != null)
                _controller.Move(ground_rb.velocity * Time.deltaTime);

            if (_velocity.y < 0.0f)
            {
                _velocity.y = -2.0f;
            }
        }

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            // The change in position this frame
            Vector3 position_delta = new Vector3();
            position_delta += (transform.right * Input.GetAxis("Horizontal")) * _movementSpeed * Time.deltaTime;
            position_delta += (transform.forward * Input.GetAxis("Vertical")) * _movementSpeed * Time.deltaTime;

            _controller.Move(position_delta);
        }
    }

    private void Jump()
    {
        if (_isGrounded && !_areControlsLocked)
            _velocity.y += Mathf.Sqrt(_jumpheight * -2.0f * _gravity);
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
