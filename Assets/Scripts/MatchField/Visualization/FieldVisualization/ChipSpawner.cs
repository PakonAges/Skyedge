using UnityEngine;

public class ChipSpawner : MonoBehaviour, IChipSpawner
{
    public GameObject SpawnChip(GameObject prefab, Vector3 position, float scale)
    {
        var newItem = Instantiate(prefab, position, Quaternion.identity);
        newItem.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(scale, scale, 1);
        return newItem;
    }
}
