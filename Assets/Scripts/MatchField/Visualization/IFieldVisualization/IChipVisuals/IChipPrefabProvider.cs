using UnityEngine;

public interface IChipPrefabProvider
{
    GameObject GetPrefab(ChipType type);
}
