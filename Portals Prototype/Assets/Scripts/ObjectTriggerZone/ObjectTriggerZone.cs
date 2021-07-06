using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectTriggerZone : MonoBehaviour
{
    [SerializeField] private string _activationTrigger;

    [SerializeField] private UnityEvent _activationEvent;
    [SerializeField] private UnityEvent _deactivationEvent;
    private bool _isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        Triggerable triggered = other.GetComponent<Triggerable>();

        if ((triggered != null) && (!_isActive))
        {
            if (triggered._triggerType == _activationTrigger)
            {
                _isActive = true;
                _activationEvent.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Triggerable triggered = other.GetComponent<Triggerable>();

        if ((triggered != null) && (_isActive))
        {
            if (triggered._triggerType == _activationTrigger)
            {
                _isActive = false;
                _deactivationEvent.Invoke();
            }
        }
    }
}
