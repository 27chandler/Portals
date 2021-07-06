using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : PlayerInput,IControllable
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private List<PlayerInput> _hangLockedControls;
    [SerializeField] private float _ledgeJumpForce;

    private bool _areControlsLocked = true;
    private bool _isHanging = false;

    void Start()
    {
        InputManager.Instance._onJump += LedgeJump;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onJump -= LedgeJump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LedgeJump()
    {
        if (_isHanging)
        {
            _rb.AddForce(transform.up * _ledgeJumpForce);
            _isHanging = false;
        }
    }

    private void ActivateHang()
    {
        _isHanging = true;
        _rb.velocity = new Vector3();
        _rb.useGravity = false;

        foreach (var control in _hangLockedControls)
        {
            control.freezeInput = true;
        }
    }

    private void DeactivateHang()
    {
        _isHanging = false;
        _rb.useGravity = true;

        foreach (var control in _hangLockedControls)
        {
            control.freezeInput = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ledge>() != null)
        {
            ActivateHang();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ledge>() != null)
        {
            DeactivateHang();
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
