using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This component causes the object to face the direction of movement
public class FaceMovement : PlayerInput, IControllable
{
    private bool _areControlsLocked = true;

    void Start()
    {
        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Move;
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked && !freezeInput)
        {
            Vector3 look_offset = new Vector3();
            look_offset += Vector3.right * movement_direction.x;
            look_offset += Vector3.forward * movement_direction.y;
            transform.LookAt(transform.position + look_offset);
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
