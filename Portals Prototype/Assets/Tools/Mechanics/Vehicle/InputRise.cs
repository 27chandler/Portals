using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRise : PlayerInput, IControllable
{
    private bool _areControlsLocked = true;

    [SerializeField] private float _thrust;
    [Space]
    [SerializeField] private Rigidbody _objectRb;

    void Start()
    {
        _objectRb.transform.parent = null;

        InputManager.Instance._onJumpHold += Rise;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onJumpHold -= Rise;
    }

    private void Rise()
    {
        if (!_areControlsLocked)
        {
            _objectRb.AddForce(Vector3.up * _thrust * Time.deltaTime);
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
