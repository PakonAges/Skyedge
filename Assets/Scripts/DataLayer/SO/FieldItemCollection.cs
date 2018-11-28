using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FieldItemCollection : ScriptableObject
{
    public Dictionary<FieldItemType,Sprite> ItemsCollection;

    public Sprite testImage;
}
