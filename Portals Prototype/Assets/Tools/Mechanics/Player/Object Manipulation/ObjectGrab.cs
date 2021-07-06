using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour, IControllable
{
    [SerializeField] private float _grabDistance = 3.0f;
    [Space]
    [SerializeField] private Transform _grabFocus;
    [SerializeField] protected ConfigurableJoint _grabFocusJoint;
    [SerializeField] private LayerMask _grabLayers;

    private Transform _grabbedObject = null;
    private Rigidbody _grabbedPhysics = null;

    private bool _areControlsLocked = false;

    void OnEnable()
    {
        InputManager.Instance._onGrab += ActivateGrab;
    }

    void OnDisable()
    {
        InputManager.Instance._onGrab -= ActivateGrab;
    }

    // Update is called once per frame
    private void ActivateGrab()
    {
        if (!_areControlsLocked)
        {
            if (_grabbedObject == null)
                InitGrab();
            else
                EndGrab();
        }
    }

    public void InitGrab()
    {
        // Raycast for object
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, _grabDistance, _grabLayers);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Grabbable>() != null)
            {
                _grabbedObject = hit.collider.transform;
                _grabFocus.transform.position = _grabbedObject.position;

                _grabbedPhysics = _grabbedObject.GetComponent<Rigidbody>();
                if (_grabbedPhysics != null)
                {
                    //_grabbedPhysics.useGravity = false;
                    _grabFocusJoint.connectedBody = _grabbedPhysics;
                }
            }
        }
    }

    public void EndGrab()
    {
        _grabbedPhysics = _grabbedObject.GetComponent<Rigidbody>();
        if (_grabbedPhysics != null)
        {
            //_grabbedPhysics.useGravity = true;
            _grabFocusJoint.connectedBody = null;
            _grabFocusJoint.targetRotation = new Quaternion(0.0f,0.0f,0.0f,1.0f);
        }
        _grabbedObject = null;
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;

        // Drop any currently held object
        if (_grabbedObject != null)
        {
            EndGrab();
        }
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
