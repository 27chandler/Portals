using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDecal : MonoBehaviour
{
    [SerializeField] private GameObject _decal;
    [SerializeField] private GameObject _paintball;
    [SerializeField] private Rigidbody _rb;

    private void OnCollisionEnter(Collision collision)
    {
        _decal.SetActive(true);
        _paintball.SetActive(false);

        transform.rotation = Quaternion.LookRotation(collision.GetContact(0).normal);
        transform.position = collision.GetContact(0).point;
        _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        _rb.isKinematic = true;
        _rb.transform.parent = collision.transform;
    }
}
