using UnityEngine;

public class ChipPrefabProvider : IChipPrefabProvider
{
    private readonly ChipTypesCollection _chipCollection;

    public ChipPrefabProvider(ChipTypesCollection chipTypesCollection)
    {
        _chipCollection = chipTypesCollection;
    }

    public GameObject GetPrefab(ChipType type)
    {
        return _chipCollection.GetChipPrefab(type);
    }
}
