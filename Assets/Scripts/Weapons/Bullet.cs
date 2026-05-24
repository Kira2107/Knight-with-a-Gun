using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [field: SerializeField] public virtual BulletDataSO bulletData { get; set; }
}
