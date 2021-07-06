using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public event Action _onRotateObject;
    public event Action _onRotateObjectInverted;

    public event Action _onJump;
    public event Action _onJumpHold;

    public event Action _onInteract;

    public event Action _onGrab;

    public event Action _onReturn;

    public event Action _onFire;

    public event Action _onSecondaryFire;

    public event Action<Vector2> _onMove;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButton("RotateObject"))
        {
            RotateObject();
        }
        else
        {
            RotateObjectInverted();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetButton("Jump"))
        {
            JumpHold();
        }

        if (Input.GetButtonDown("Grab"))
        {
            Grab();
        }

        if (Input.GetButtonDown("Interact"))
        {
            Interact();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Return();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SecondaryFire();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
        {
            Vector2 movement = new Vector2();
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            Move(movement);
        }
    }

    public void Move(Vector2 direction)
    {
        _onMove?.Invoke(direction);
    }

    public void Grab()
    {
        _onGrab?.Invoke();
    }

    public void RotateObject()
    {
        if (_onRotateObject != null)
        {
            _onRotateObject();
        }
    }

    public void RotateObjectInverted()
    {
        if (_onRotateObjectInverted != null)
        {
            _onRotateObjectInverted();
        }
    }

    public void Jump()
    {
        if (_onJump != null)
        {
            _onJump();
        }
    }

    public void JumpHold()
    {
        if (_onJumpHold != null)
        {
            _onJumpHold();
        }
    }

    public void Fire()
    {
        if (_onFire != null)
        {
            _onFire();
        }
    }

    private void SecondaryFire()
    {
        if (_onSecondaryFire != null)
        {
            _onSecondaryFire();
        }
    }

    public void Interact()
    {
        //if (_onInteract != null)
        //{
        //    _onInteract();
        //}

        // Above and below are the same
        _onInteract?.Invoke();
    }

    public void Return()
    {
        _onReturn?.Invoke();
    }
}
