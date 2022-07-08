using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Vector2 _movementVector;

    [SerializeField] private float _period = 3f;

    private const float _tau = Mathf.PI * 2;
    private float _cycles;
    private float _rawSinWave;
    private float _movementFactor;
    private Vector3 _startPos;
    private Vector3 _offset;

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        if (_period <= 0)
            return;

        _cycles = Time.time / _period;
        _rawSinWave = Mathf.Sin(_cycles * _tau);
        _movementFactor = _rawSinWave / 2f + 0.5f;
        _offset = _movementFactor * _movementVector;

        transform.position = _startPos + _offset;
    }
}

