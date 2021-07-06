using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightInteractor : MonoBehaviour
{
    [SerializeField] private float _interactDistance = 3.0f;

    [SerializeField] private List<SightTrigger> _activeTriggers = new List<SightTrigger>();

    // Update is called once per frame
    void Update()
    {
        // Raycast for interaction trigger
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, _interactDistance);

        if (hit.collider != null)
        {
            SightTrigger[] triggered_sights = hit.collider.GetComponents<SightTrigger>();
            foreach (var trigger in triggered_sights)
            {
                if (trigger != null)
                {
                    if (!_activeTriggers.Contains(trigger))
                    {
                        _activeTriggers.Add(trigger);
                        trigger.Activate();
                    }
                }
            }

            for (int i = _activeTriggers.Count - 1; i >= 0; i--)
            {
                bool is_trigger_active = false;
                for (int j = 0; j < triggered_sights.Length; j++)
                {
                    if (triggered_sights[j] == _activeTriggers[i])
                    {
                        is_trigger_active = true;
                    }
                }

                if (!is_trigger_active)
                {
                    _activeTriggers[i].Deactivate();
                    _activeTriggers.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = _activeTriggers.Count - 1; i >= 0; i--)
            {
                _activeTriggers[i].Deactivate();
                _activeTriggers.RemoveAt(i);
            }
        }
    }
}
