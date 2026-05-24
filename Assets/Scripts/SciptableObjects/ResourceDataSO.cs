using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceDataSO", menuName = "Custom Scriptable Objects/ResourceDataSO")]
public class ResourceDataSO : ScriptableObject
{
    [field: SerializeField] public ResourceTypeEnum resourceType { set; get; }
    [SerializeField] private int minAmount = 1, maxAmount = 5;
    public int GetAmount()
    {
        return UnityEngine.Random.Range(minAmount, maxAmount + 1);
    }
}

public enum ResourceTypeEnum
{
    None,
    Health,
    Ammo

}
