using UnityEngine;

[CreateAssetMenu(fileName = "MovementSO", menuName = "Custom Scriptable Objects/MovementSO")]
public class MovementSO : ScriptableObject
{
    [Range(1,10)] public float maxSpeed = 5f; // Maximum speed of the agent
    [Range(0.1f,100)] public float acceleration = 50f; // Acceleration of the agent
    [Range(0.1f,100)] public float deceleration = 50f; // Deceleration of the agent

}
