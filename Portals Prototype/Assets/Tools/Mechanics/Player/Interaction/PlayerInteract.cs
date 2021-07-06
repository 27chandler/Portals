using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour,  IControllable
{
    [SerializeField] private float _interactDistance = 3.0f;
    [Space]
    [SerializeField] public Transform _player;

    private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onInteract += Interact;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onInteract -= Interact;
    }

    void Update()
    {
        
    }

    private void Interact()
    {
        if (!_areControlsLocked)
        {
            // Raycast for interaction trigger
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, _interactDistance);

            if (hit.collider != null)
            {
                Interaction[] triggered_interactions = hit.collider.GetComponents<Interaction>();
                foreach (var interaction in triggered_interactions)
                {
                    if (interaction != null)
                    {
                        interaction.ActivateInteraction(this);
                    }
                }
            }
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
