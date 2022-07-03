using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] Transform _shootPoint;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _animator.SetTrigger("Attack");
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
