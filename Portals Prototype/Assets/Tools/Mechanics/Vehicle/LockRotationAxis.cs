using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationAxis : MonoBehaviour
{
    [SerializeField] private bool _isXRotationLocked;
    [SerializeField] private bool _isYRotationLocked;
    [SerializeField] private bool _isZRotationLocked;

    private void Update()
    {
        Vector3 final_rotation = transform.rotation.eulerAngles;

        if (_isXRotationLocked)
            final_rotation.x = 0.0f;
        if (_isYRotationLocked)
            final_rotation.y = 0.0f;
        if (_isZRotationLocked)
            final_rotation.z = 0.0f;

        transform.rotation = Quaternion.Euler(final_rotation);
    }
}
