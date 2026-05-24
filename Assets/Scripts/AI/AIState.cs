using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    [field: SerializeField] private EnemyAIBrain enemyBrain = null;
    [field: SerializeField] private List<AIAction> actions = null;
    [field: SerializeField] private List<AITransition> transitions = null;

    void Awake()
    {
        enemyBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in actions)
        {
            action.TakeAction();
        }

        foreach (var transition in transitions)
        {
            //Player in Range -> True -> Back to Idle
            //Player is Visible -> True -> Chase Player

            bool result = false;
            foreach (var decision in transition.Decisions)
            {
                result = decision.MakeADecision();
                // if (!result)
                // {
                //     break; // If any decision returns false, we stop checking further
                // }
                
                if (result)
                {
                    if (transition.PositiveResult != null)
                    {
                        enemyBrain.ChangeToState(transition.PositiveResult);
                        return; // Exit after a positive transition
                    }

                }
                else
                {
                    if (transition.NegativeResult != null)
                    {
                        enemyBrain.ChangeToState(transition.NegativeResult);
                        return; // Exit after a negative transition
                    }
                }
            }
        }
    }
        
}
