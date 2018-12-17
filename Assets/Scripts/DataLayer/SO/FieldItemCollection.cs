using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Items Collection")]
public class FieldItemCollection : ScriptableObject
{
    public GameObject EmptyGridCell;
    public ChipPrefab[] ChipPrefabCollection;
    public NormalChipVisual[] NormalChipVisual;

    public Sprite GetItemImage(NormalChipType Type)
    {
        for (int i = 0; i < NormalChipVisual.Length; i++)
        {
            if (NormalChipVisual[i].Type == Type)
            {
                return NormalChipVisual[i].Image;
            }
        }

        return NormalChipVisual[0].Image;
    }
}

[System.Serializable] 
public struct ChipPrefab
{
    public ChipType Type;
    public GameObject Prefab;
}

[System.Serializable]
public struct NormalChipVisual
{
    public NormalChipType Type;
    public Sprite Image;
}
