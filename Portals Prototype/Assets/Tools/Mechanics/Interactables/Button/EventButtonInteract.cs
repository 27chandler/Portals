using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventButtonInteract : Interaction
{
    [SerializeField] private int _state = 0;
    [SerializeField] private List<UnityEvent> _activationEvents;

    public override void ActivateInteraction(PlayerInteract player_interactor)
    {
        _state++;
        if (_state >= _activationEvents.Count)
        {
            _state = 0;
        }

        _activationEvents[_state].Invoke();
    }
}
