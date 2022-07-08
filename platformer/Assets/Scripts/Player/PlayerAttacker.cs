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
    [SerializeField] private float _reloadingTime;

    private float _lastShotTime;

    private Animator _animator;
    private Player _player;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _lastShotTime -= Time.deltaTime;
        Aim();
    }

    private void Aim()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    public void Shoot()
    {
        if (_lastShotTime <= 0)
        {
            _animator.SetTrigger("Attack");
            Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            _lastShotTime = _reloadingTime;
        }
    }
}
