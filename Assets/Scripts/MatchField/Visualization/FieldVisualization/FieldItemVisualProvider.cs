using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItemVisualProvider : IFieldItemVisualProvider
{
    private FieldItemCollection _fieldItemCollection;

    public FieldItemVisualProvider(FieldItemCollection fieldItemCollection)
    {
        _fieldItemCollection = fieldItemCollection;
    }

    public Sprite GetItemSprite(FieldItemType type)
    {
        return _fieldItemCollection.GetItemImage(type);
    }
}
