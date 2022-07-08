using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private SpriteRenderer _spriteRenderer; 

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    public bool FacingRight { get; set; }

    private void Start()
    {
        FacingRight = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        StartCoroutine(DamageAnimation());
    }

    private IEnumerator DamageAnimation()
    {
        Color startColor = Color.white;
        Color blinkColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);

        for (int i = 0; i < 3; i++)
        {
            _spriteRenderer.color = blinkColor;
            yield return new WaitForSeconds(0.2f);

            _spriteRenderer.color = startColor;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
