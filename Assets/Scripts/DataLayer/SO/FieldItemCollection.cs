using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Items Collection")]
public class FieldItemCollection : ScriptableObject
{
    public List<FieldItemPresentation> ItemCollection;

    public Sprite GetItemImage(FieldItemType Type)
    {
        for (int i = 0; i < ItemCollection.Count; i++)
        {
            if (ItemCollection[i].Type == Type)
            {
                return ItemCollection[i].Image;
            }
        }

        return ItemCollection[0].Image;
    }
}

[System.Serializable] 
public struct FieldItemPresentation
{
    public FieldItemType Type;
    public Sprite Image;
}
