using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAIPaddle : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _borderTop, _borderBottom;
    [SerializeField] private float _moveBuffer;
    [Space]
    [SerializeField] private float _acceleration;

    private Vector3 _movement = new Vector3(0.0f,0.0f,0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_ball.localPosition.y > transform.localPosition.y + _moveBuffer)
        {
            _movement.y += _acceleration;
        }
        else if (_ball.localPosition.y < transform.localPosition.y - _moveBuffer)
        {
            _movement.y -= _acceleration;
        }
        else
        {
            _movement.y = 0.0f;
        }

        // Stops the AI paddle increasing to light speed
        _movement.y = Mathf.Clamp(_movement.y, -_moveSpeed, _moveSpeed);

        // Prevents the paddle from escaping the game zone
        if ((_ball.localPosition.y > transform.localPosition.y + _moveBuffer) && (transform.localPosition.y >= _borderTop))
        {
            return;
        }
        if ((_ball.localPosition.y < transform.localPosition.y - _moveBuffer) && (transform.localPosition.y <= _borderBottom))
        {
            return;
        }

        transform.localPosition += _movement * Time.deltaTime;
    }
}
