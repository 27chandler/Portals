using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLinearGravity : MonoBehaviour
{
    [SerializeField] private Vector3 _gravityDirection;
    [SerializeField] private float _gravityStrength;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.AddForce((_gravityDirection.normalized * _gravityStrength * Time.deltaTime) * Mathf.Clamp((1.0f/ _rb.velocity.magnitude + 0.01f),0.0f,10.0f));
    }
}
