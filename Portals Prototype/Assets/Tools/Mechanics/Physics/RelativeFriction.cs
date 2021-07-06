using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeFriction : MonoBehaviour
{
    [SerializeField] private GroundedCheck _groundCheck;
    [SerializeField] private float _frictionStrength;

    private Rigidbody _rb;
    [SerializeField] private Vector3 _friction;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_groundCheck._groundObject != null)
        {
            Rigidbody _groundRb = _groundCheck._groundObject.GetComponent<Rigidbody>();

            if (_groundRb != null)
            {
                _friction = _groundRb.velocity - _rb.velocity * _frictionStrength * Time.deltaTime;
            }
            else
            {
                _friction = -_rb.velocity * _frictionStrength * Time.deltaTime;
                
            }
            _rb.AddForce(_friction);
        }
    }
}
