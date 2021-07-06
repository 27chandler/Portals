using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SightTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _activationEvent;
    [SerializeField] private UnityEvent _deactivationEvent;

    public void Activate()
    {
        _activationEvent.Invoke();
    }

    public void Deactivate()
    {
        _deactivationEvent.Invoke();
    }
}
