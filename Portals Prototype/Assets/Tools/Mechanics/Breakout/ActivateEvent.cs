using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEvent;

    private void OnCollisionEnter(Collision collision)
    {
        _triggerEvent.Invoke();
    }
}
