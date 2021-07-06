using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearGravity : MonoBehaviour
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
        _rb.AddForce(_gravityDirection.normalized * _gravityStrength * Time.deltaTime);
    }
}
