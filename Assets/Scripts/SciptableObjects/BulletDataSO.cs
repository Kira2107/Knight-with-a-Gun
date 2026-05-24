using UnityEngine;

[CreateAssetMenu(fileName = "BulletDataSO", menuName = "Custom Scriptable Objects/BulletDataSO")]
public class BulletDataSO : ScriptableObject
{
    [field: SerializeField] public GameObject BulletPrefab { get; set; }
    [field: SerializeField][field: Range(1f, 100f)] public float BulletSpeed { get; internal set; } = 1f;
    [field: SerializeField][field: Range(1, 10)] public int Damage { get; set; } = 1;
    [field: SerializeField][field: Range(0f, 100f)] public float Friction { get; internal set; } = 0f;
    [field: SerializeField] public bool Bounce { get; set; }
    [field: SerializeField] public bool GoThroughHittable { get; set; }
    [field: SerializeField] public bool IsRaycast { get; set; }
    [field: SerializeField] public GameObject ImpactObstaclePrefab { get; set; }
    [field: SerializeField] public GameObject ImpactEnemyPrefab { get; set; }
    [field: SerializeField][field: Range(1, 100)] public float KnockBackPower { get; set; } = 5f;
    [field: SerializeField][field: Range(0.1f, 10f)] public float KnockBackDelay { get; set; } = 0.1f;
    [field: SerializeField] public LayerMask BulletLayerMask { get; set; }

}
