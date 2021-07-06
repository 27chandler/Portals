using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PortalTransfer : MonoBehaviour
{
    [SerializeField] private string _transferLayer;

    [SerializeField] private List<Traveller> _travellers = new List<Traveller>();

    [Serializable]
    public struct Traveller
    {
        public Transform transform;
        public Vector3 last_pos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = _travellers.Count - 1; i >= 0; i--)
        {
            if (Vector3.Dot((_travellers[i].last_pos - _travellers[i].transform.position).normalized,transform.forward) < 0.0f)
            {
                Travel(_travellers[i].transform);
                _travellers.RemoveAt(i);
            }
        }
    }

    private void Travel(Transform traveller)
    {
        traveller.gameObject.layer = LayerMask.NameToLayer(_transferLayer);
        if (traveller.tag == "Player")
        {
            Camera.main.cullingMask = (int)Mathf.Pow(2, (float)(LayerMask.NameToLayer(_transferLayer)));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            return;
        }
        Traveller new_traveller = new Traveller();
        new_traveller.transform = other.transform;
        new_traveller.last_pos = other.transform.position;
        _travellers.Add(new_traveller);
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = _travellers.Count - 1; i >= 0 ; i--)
        {
            if (_travellers[i].transform == other.transform)
            {
                _travellers.RemoveAt(i);
            }
        }
    }
}
