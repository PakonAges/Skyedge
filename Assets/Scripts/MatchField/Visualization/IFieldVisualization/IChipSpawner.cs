using UnityEngine;

public interface IChipSpawner
{
    GameObject SpawnChip(GameObject prefab, Vector3 position, float scale);
}
