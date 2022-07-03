using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PatrollingEnemy : Enemy
{
    [SerializeField] private float _distance = 2f;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;
    private bool _movingRight = false;

    private RaycastHit2D _groundInfo;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _groundInfo = Physics2D.Raycast(_groundPoint.position, Vector2.down, _distance, _groundLayer);

        CheckGround(_groundInfo);
    }

    private void CheckGround(RaycastHit2D groundInfo)
    {
        if (groundInfo.collider != false)
        {
            if (_movingRight)
            {
                Move(Speed);
            }
            else
            {
                Move(-Speed);
            }
        }
        else
        {
            _movingRight = !_movingRight;
            transform.Rotate(0, 180, 0);
        }
    }

    private void Move(float speed)
    {
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }
}
