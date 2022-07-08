using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Player))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private float _offset;

    private Animator _animator;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);
    }

    public void Shoot()
    {
        _animator.SetTrigger("Attack");
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
