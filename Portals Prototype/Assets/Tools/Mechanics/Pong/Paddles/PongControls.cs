using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongControls : PlayerInput, IControllable
{
    [SerializeField] private bool _areControlsLocked;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _borderTop, _borderBottom, _borderLeft, _borderRight;
    [SerializeField] private bool _canMoveHorizontal = false, _canMoveVertical = true;

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
        if (!_areControlsLocked)
        {
            Vector3 movement = new Vector3();
            if (_canMoveVertical)
                movement.y = movement_direction.y;
            if (_canMoveHorizontal)
                movement.x = movement_direction.x;

            if ((movement.y > 0.0f) && (transform.localPosition.y >= _borderTop))
            {
                return;
            }
            if ((movement.y < 0.0f) && (transform.localPosition.y <= _borderBottom))
            {
                return;
            }
            if ((movement.x > 0.0f) && (transform.localPosition.x >= _borderRight))
            {
                return;
            }
            if ((movement.x < 0.0f) && (transform.localPosition.x <= _borderLeft))
            {
                return;
            }

            transform.localPosition += movement * _moveSpeed * Time.deltaTime;
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
