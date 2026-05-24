using UnityEngine;

public class DistanceDecision : AIDecision
{
    [field: SerializeField][Range(0.1f, 10)] public float Distance { get; set; } = 5f;
    public override bool MakeADecision()
    {
        if (Vector3.Distance(enemyBrain.Target.transform.position, transform.position) < Distance)
        {
            if (aIActionData.TargetSpotted == false)
            {
                aIActionData.TargetSpotted = true;
            }
        }
        else
        {
            aIActionData.TargetSpotted = false;
        }
        return aIActionData.TargetSpotted;
    }
    
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Distance);
    }
}
