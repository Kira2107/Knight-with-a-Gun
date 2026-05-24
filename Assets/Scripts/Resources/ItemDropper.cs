using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnData> itemsToDrop = new List<ItemSpawnData>();
    float[] itemWeights;
    [SerializeField][Range(0f, 1f)] private float dropChance = 0.5f;

    void Start()
    {
        itemWeights = itemsToDrop.Select(item => item.spawnChance).ToArray();
    }

    public void DropItem()
    {
        var dropVariable = Random.value;
        if (dropVariable < dropChance)
        {
            int index = GetRandomWeightedIndex(itemWeights);
            Instantiate(itemsToDrop[index].itemPrefab, transform.position, Quaternion.identity);
        }
    }

    private int GetRandomWeightedIndex(float[] itemWeights)
    {
        float sum = 0f;
        for (int i = 0; i < itemWeights.Length; i++)
        {
            sum += itemWeights[i];
        }

        float randomValue = Random.Range(0f, sum);
        float tempSum = 0f;

        for (int i = 0; i < itemsToDrop.Count; i++)
        {
            if (randomValue >= tempSum && randomValue < tempSum + itemsToDrop[i].spawnChance)
            {
                return i;
            }
            else
            {
                tempSum += itemWeights[i];
            }
        }

        return 0;
    }
}

[System.Serializable]
public struct ItemSpawnData
{
    [Range(0f, 1f)] public float spawnChance;
    public GameObject itemPrefab;
    
}
