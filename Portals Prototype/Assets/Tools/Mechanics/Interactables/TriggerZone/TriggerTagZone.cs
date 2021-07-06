using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTagZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _activationEvent;
    [SerializeField] private string _activationTag;

    private void OnTriggerEnter(Collider other)
    {
        TriggerTag _collidingTag = other.GetComponent<TriggerTag>();

        if (_collidingTag != null)
        {
            if (_collidingTag._tag == _activationTag)
            {
                _activationEvent.Invoke();
            }
        }
    }
}
