using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private LayerMask _maskGround;

    private float _groundCheckRadius = 0.01f;

    private Player _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public float Speed { get; private set; }

    public bool IsJump { get; private set; }
    

    private void Awake()
    {
        IsJump = false;
        Speed = _speed;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        OnGround(!Physics2D.OverlapCircle(_groundPoint.position, _groundCheckRadius, _maskGround));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
            gameObject.transform.parent = collision.transform;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.transform.parent = null;
    }

    private void OnGround(bool isJumped)
    {
        _animator.SetBool("isJump", isJumped);
        IsJump = isJumped;
    }

    public void Jump()
    {
        if (!IsJump)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
          //  _rigidbody.AddForce(Vector2.up * _speed * _jumpForce, ForceMode2D.Impulse);
        }
    }

    public void MouseFlip()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (pos.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (pos.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void Move(float xMovement)
    {
        _rigidbody.velocity = new Vector2(xMovement, _rigidbody.velocity.y);
        _animator.SetBool("isRunning", true);
    }

    public void StopMove()
    {
        _rigidbody.velocity = Vector2.zero;
        _animator.SetBool("isRunning", false);
    }
}
