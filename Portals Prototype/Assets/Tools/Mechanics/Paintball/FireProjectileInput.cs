using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectileInput : PlayerInput
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _shootForce;
    [SerializeField] private Transform _shootPoint;

    // Start is called before the first frame update
    void OnEnable()
    {
        InputManager.Instance._onFire += Fire;
    }

    private void OnDisable()
    {
        InputManager.Instance._onFire -= Fire;
    }

    private void Fire()
    {
        GameObject new_projectile = Instantiate(_projectile, _shootPoint.position, new Quaternion());

        Rigidbody projectile_rb = new_projectile.GetComponent<Rigidbody>();
        if (projectile_rb != null)
        {
            projectile_rb.AddForce(-transform.forward * _shootForce);
        }
        else
        {
            Debug.LogError("Error: Projectile has no rigidbody component");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_shootPoint.position, 0.3f);
    }
}
