using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAttacker))]
public class PlayerInput : MonoBehaviour
{
    private float _xInput;
   
    private PlayerMover _mover;
    private PlayerAttacker _attacker;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _attacker = GetComponent<PlayerAttacker>();
    }

    private void Update()
    { 
        MoveInput();
        JumpInput();
        ShootInput();
    }

    private void MoveInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _mover.Move(-_mover.Speed);
            _mover.FlipLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _mover.Move(_mover.Speed);
            _mover.FlipRight();
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _mover.StopMove();
    }

    private void JumpInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _mover.Jump();
        }
    }

    private void ShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _attacker.Shoot();
        }
    }
}
