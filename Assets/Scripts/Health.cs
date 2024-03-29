using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HurtEvent(Transform attackerTransform);

    public delegate void HealEvent();

    public delegate void DeathEvent();

    [SerializeField]
    private int _maxHealthPoints = 10;

    [SerializeField]
    private int _healthPoints;
    [SerializeField] private bool _destroyWhenKilled = true;

    private Rigidbody2D _rb;

    public HurtEvent OnHurt { get; set; }
    public HealEvent OnHeal { get; set; }
    public DeathEvent OnDeath { get; set; }
    public bool CanReceiveDamage { get; set; } = true;
    public bool IsDead => _healthPoints <= 0;
    public int HealthPoints => _healthPoints;
    public EnemyController _ec;
    private void Awake()
    {
        _ec = GetComponent<EnemyController>();
        _rb = GetComponent<Rigidbody2D>();
        _healthPoints = _maxHealthPoints;
    }

    public void HealPlayer(int heal)
    {
        _healthPoints += heal;
        if (_healthPoints > _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }

        OnHeal?.Invoke();
    }

    public void Hurt(int hurtAmount, Transform attackerTransform = null)
    {
        if (!CanReceiveDamage) return;

        _healthPoints -= hurtAmount;
        _ec.TakeDamage();
        OnHurt?.Invoke(attackerTransform);

        if (!IsDead) return;

        OnDeath?.Invoke();
        if (!_destroyWhenKilled) return;
        Destroy(gameObject, 0.2f);
    }
}
