using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour, IScoreActivatable
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _bounceIncrement;
    [SerializeField] private int _maxBounceIncrements;
    [Space]
    [SerializeField] private float _ballResetFreezeTime = 1.0f;

    private Vector3 _movementDirection = new Vector3(1.0f, 1.0f,0.0f);
    private int _bounceCount = 0;

    private Vector3 _startPos = new Vector3();
    private float _unfreezeTimer = 0.0f;
    private bool _isBallFrozen = true;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // If the ball is frozen, do the unfreeze countdown,
        // Otherwise: move the ball like normal
        if (_isBallFrozen)
        {
            if (_unfreezeTimer < _ballResetFreezeTime)
            {
                _unfreezeTimer += Time.deltaTime;
            }
            else
            {
                _isBallFrozen = false;
            }
        }
        else
        {
            transform.localPosition += _movementDirection * (_movementSpeed + (_bounceCount * _bounceIncrement)) * Time.deltaTime;
        }
    }

    public void ResetBall()
    {
        _isBallFrozen = true;
        _bounceCount = 0;
        _unfreezeTimer = 0.0f;
        transform.localPosition = _startPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _movementDirection = Vector3.Reflect(_movementDirection, transform.parent.InverseTransformDirection(collision.GetContact(0).normal));

        if (_bounceCount < _maxBounceIncrements)
        {
            _bounceCount++;
        }
    }
}
