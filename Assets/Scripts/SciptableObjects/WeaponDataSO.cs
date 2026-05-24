using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "Custom Scriptable Objects/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public BulletDataSO BulletData { get; set; }

    [field: SerializeField][field: Range(0, 100)] public int AmmoCapacity { get; internal set; } = 100;
    [field: SerializeField] public bool AutomaticFire { get; internal set; } = false;
    [field: SerializeField][field: Range(0.1f, 2f)] public float WeaponDelay { get; internal set; } = 0.1f;
    [field: SerializeField][field: Range(0, 10f)] public float SpreadAngle { get; set; } = 5;
    [SerializeField] private bool multiBulletShot = false;
    [SerializeField][field: Range(1, 10f)] private int bulletCount = 1;

    public int GetBulletCountToSpawn()
    {
        if (multiBulletShot)
        {
            return bulletCount;
        }
        return 1;
    }
}
