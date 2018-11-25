using UnityEngine;

public interface IFieldItemVisualProvider
{
    Sprite GetItemSprite(FieldItemTypes.FieldItemType fieldItemType);

}
