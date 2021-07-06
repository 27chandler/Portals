using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody _carRb;

    [SerializeField] private Transform _groundCheck;

    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _inAirDrag;

    private float _defaultDrag;
    public bool _isGrounded {get; set; } = false;
    public GameObject _groundObject { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        _defaultDrag = _carRb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        RaycastHit hit;
        Physics.Raycast(_groundCheck.position, Vector3.down, out hit, _groundCheckDistance);

        if (hit.collider != null)
        {
            _isGrounded = true;

            _groundObject = hit.collider.gameObject;
            _carRb.drag = _defaultDrag;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else
        {
            _isGrounded = false;

            _groundObject = null;
            _carRb.drag = _inAirDrag;
        }
    }
}
