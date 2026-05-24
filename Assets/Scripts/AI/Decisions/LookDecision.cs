using UnityEngine;
using UnityEngine.Events;

public class LookDecision : AIDecision
{
    [SerializeField][Range(1, 15)] private float lookRange = 15f;
    [SerializeField] private LayerMask rayCastMask = new LayerMask();

    [field: SerializeField] public UnityEvent OnPlayerSpotted { get; set; }

    public override bool MakeADecision()
    {
        var direction = enemyBrain.Target.transform.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, lookRange, rayCastMask);

        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnPlayerSpotted?.Invoke();
            return true;
        }

        return false;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (UnityEditor.Selection.activeGameObject == gameObject && enemyBrain != null && enemyBrain.Target != null)
        {
            Gizmos.DrawRay(transform.position, (enemyBrain.Target.transform.position - transform.position).normalized);
        }
    }
    #endif
}
