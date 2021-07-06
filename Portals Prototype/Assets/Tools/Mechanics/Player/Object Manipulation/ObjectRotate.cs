using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : ObjectGrab
{
    [SerializeField] private float _rotationSensitivity = 100.0f;

    void Start()
    {
        InputManager.Instance._onRotateObject += ControlRotation;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onRotateObject -= ControlRotation;
    }

    private void ControlRotation()
    {
        Vector3 object_rotation = _grabFocusJoint.targetRotation.eulerAngles;

        object_rotation.y += Input.GetAxis("Mouse X") * Time.deltaTime * _rotationSensitivity;
        //object_rotation.z += Input.GetAxis("Mouse Y") * Time.deltaTime * _rotationSensitivity;

        _grabFocusJoint.targetRotation = Quaternion.Euler(object_rotation);
    }

}
