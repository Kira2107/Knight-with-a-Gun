using System.Collections;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    private EnemyAIBrain enemyBrain;
    [field: SerializeField] public float AttackDelay { get; private set; } = 1f;
    protected bool waitBeforeNextAttack = false;


    void Awake()
    {
        enemyBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);
    protected IEnumerator WaitBeforeAttackCoroutine()
    {
        waitBeforeNextAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeNextAttack = false;
    }

    protected GameObject GetTarget()
    {
        return enemyBrain.Target;
    }
}
