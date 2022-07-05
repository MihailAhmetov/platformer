using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float _climbingSpeed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            GravityTurn(player, 0);


            if (Input.GetKey(KeyCode.W))
                MoveOnLadder(player, _climbingSpeed);
            else if (Input.GetKey(KeyCode.S))
                MoveOnLadder(player, -_climbingSpeed);
            else
                MoveOnLadder(player, 0);   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            GravityTurn(player, 1);
        }
    }

    private static void GravityTurn(Player player, int value)
    {
        player.gameObject.GetComponent<Rigidbody2D>().gravityScale = value;
    }

    private void MoveOnLadder(Player player, float climbingSpeed)
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climbingSpeed);
    }
}
