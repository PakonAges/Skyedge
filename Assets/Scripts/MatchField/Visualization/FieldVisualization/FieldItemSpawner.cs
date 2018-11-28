using UnityEngine;

public class FieldItemSpawner : MonoBehaviour, IFieldItemSpawner
{
    public GameObject FieldItemGo;

    public void CreateItem(Sprite image, Vector3 position)
    {
        var newItem = Instantiate(FieldItemGo, position, Quaternion.identity);
        newItem.GetComponent<SpriteRenderer>().sprite = image;
    }
}
