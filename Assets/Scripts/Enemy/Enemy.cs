using System.Collections;
using UnityEngine;
using UnityEngine.Events;



public class Enemy : MonoBehaviour, IHittable, IAgent, IKnockBack
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; private set; }
    [field: SerializeField] public int Health { get; private set; } = 2;
    [field: SerializeField] public EnemyAttack enemyAttack { get; private set; }
    private bool isDead = false;
    private AgentMovement agentMovement;
    [field: SerializeField] public UnityEvent OnGetHit { get; set; }
    [field: SerializeField] public UnityEvent OnDeath { get; set; }

    void Awake()
    {
        if (enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
            agentMovement = GetComponent<AgentMovement>();
        }
    }

    void Start()
    {
        if (EnemyData != null)
        {
            Health = EnemyData.MaxHealth;
        }
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (!isDead)
        {
            Health -= damage;
            OnGetHit?.Invoke();

            if (Health <= 0)
            {
                isDead = true;
                OnDeath?.Invoke();
            }
        }
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    public void PerformAttack()
    {
        if (!isDead)
        {
            enemyAttack.Attack(EnemyData.Damage);
        }
    }

    public void KnockBack(Vector2 direction, float power, float duration)
    {
        agentMovement.KnockBack(direction, power, duration);
    }
}
