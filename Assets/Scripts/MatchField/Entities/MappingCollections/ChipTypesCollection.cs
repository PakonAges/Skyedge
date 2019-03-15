using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Chip Types Collection")]
public class ChipTypesCollection : ScriptableObject
{
    [Header("Null Chip Object")]
    public GameObject NullChipObject;

    [Header("Chip Types Mapping to prefabs")]
    public ChipPrefab[] ChipPrefabCollection;

    public GameObject GetChipPrefab(ChipType type)
    {
        for (int i = 0; i < ChipPrefabCollection.Length; i++)
        {
            if (ChipPrefabCollection[i].Type == type)
            {
                return ChipPrefabCollection[i].Prefab;
            }
        }

        Debug.LogErrorFormat("Can't find prefab in collection for this Chip type: {0}", type);
        return NullChipObject;
    }
}

[System.Serializable] 
public struct ChipPrefab
{
    public ChipType Type;
    public GameObject Prefab;
}