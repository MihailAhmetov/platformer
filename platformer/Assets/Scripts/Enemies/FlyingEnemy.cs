using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class FlyingEnemy : Enemy
{
    [SerializeField] private float _targetDistance;

    private Player _target;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector3 _startPoint;
    private Vector2 _moveDirection;

    private void Start()
    {
        _startPoint = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

   
    private void Move()
    {
        if (Vector2.Distance(transform.position, _target.transform.position) < _targetDistance)
        {
            MoveToNextDestination(_target.transform.position);
        }
        else if(Vector2.Distance(transform.position, _startPoint) < 0.1f)
        {
            _rigidbody.velocity = new Vector2(0,0);
            _animator.SetBool("isFlying", false);
        }
        else 
        {
            MoveToNextDestination(_startPoint);
        }
    }

    private void MoveToNextDestination(Vector3 targetDestination)
    {
        _moveDirection = GetMoveDirection(targetDestination);
        _animator.SetBool("isFlying", true);
        _rigidbody.velocity = new Vector2(_moveDirection.x * Speed, _moveDirection.y * Speed);
    }

    private Vector2 GetMoveDirection(Vector3 targetPosition)
    {
        Vector2 direction;
       
        if (transform.position.x < targetPosition.x) 
            direction.x = 1;
        else
            direction.x = -1;

        if (transform.position.y < targetPosition.y)
            direction.y = 1;
        else
            direction.y = -1;

        return direction;
    }
}
