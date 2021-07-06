using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followDistance;
    [SerializeField] private float _followHeight;
    [SerializeField] private Transform _followTarget;

    private Rigidbody _rb;
    private float _zoomDistance;
    private Vector3 _setPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        transform.SetParent(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateCamPosition();

        transform.LookAt(_followTarget,Vector3.up);

        //transform.position = _followTarget.position + _followPos;
    }

    private void CalculateCamPosition()
    {
        Vector3 target_forward_flattened = _followTarget.forward;
        target_forward_flattened.y = 0.0f;
        target_forward_flattened.Normalize();

        RaycastHit hit;
        Physics.Raycast(_followTarget.position, -_followTarget.forward, out hit, _followDistance + 0.5f);

        if (hit.collider == null)
        {
            _setPosition = _followTarget.position - (target_forward_flattened * _followDistance) + (Vector3.up * _followHeight);
        }
        else
        {
            _setPosition = hit.point + (Vector3.up * _followHeight) + (_followTarget.forward * 0.5f);
        }

        _rb.position = Vector3.Lerp(_rb.position, _setPosition, 0.1f);
    }
}
