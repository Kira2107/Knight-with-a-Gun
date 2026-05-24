using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Custom Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    [field: SerializeField]public int MaxHealth { get; set; } = 3;
    [field: SerializeField]public int Damage { get; set; } = 1;

}
