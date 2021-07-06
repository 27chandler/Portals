using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour, IControllable
{
    [SerializeField] private float _mouseSensitivity = 100.0f;

    [SerializeField] private Transform _playerBody;

    private float _xRotation = 0.0f;
    private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onRotateObjectInverted += Look;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onRotateObjectInverted -= Look;
    }

    void Look()
    {
        if (!_areControlsLocked)
        {
            float mouse_x = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            float mouse_y = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

            _xRotation -= mouse_y;
            _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
            _playerBody.Rotate(Vector3.up * mouse_x);
        }
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
