using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FocusInteraction : Interaction,  IControllable
{
    [SerializeField] private bool _isActive = false;
    [Space]
    [SerializeField] private PlayerRegister _focusRegister;
    [SerializeField] private UnityEvent _activateEvent;

    private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onReturn += CancelFocus;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onReturn -= CancelFocus;
    }

    public override void ActivateInteraction(PlayerInteract player_interactor)
    {
        _focusRegister.enabled = true;
        _isActive = true;
        _activateEvent.Invoke();
    }

    private void CancelFocus()
    {
        if (!_areControlsLocked)
        {
            _focusRegister.enabled = false;
            _isActive = false;
        }
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
        CancelFocus();
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
