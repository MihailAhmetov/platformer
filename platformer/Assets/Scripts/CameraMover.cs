using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _dumping = 1.5f;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 1f);

    private int _lastX;

    void Start()
    {
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
    }

    void Update()
    {
        if (_player)
        {
            int currentX = Mathf.RoundToInt(_player.transform.position.x);

            Vector3 target;

            if(_player.FacingRight)
                target = new Vector3(_player.transform.position.x + _offset.x, _player.transform.position.y + _offset.y, transform.position.z);
            else
                target = new Vector3(_player.transform.position.x - _offset.x, _player.transform.position.y + _offset.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    private void IsLeft(bool playerLookingLeft)
    {
        _lastX = Mathf.RoundToInt(_player.transform.position.x);

        if (playerLookingLeft)
            transform.position = new Vector3(_player.transform.position.x - _offset.x, _player.transform.position.x - _offset.x, _player.transform.position.z);
        else
            transform.position = new Vector3(_player.transform.position.x + _offset.x, _player.transform.position.x + _offset.x, _player.transform.position.z);
    }
}
