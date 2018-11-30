using UnityEngine;

public class FieldItemSpawner : MonoBehaviour, IFieldItemSpawner
{
    public GameObject FieldItemGo;

    public void CreateItem(Sprite image, Vector3 position, float scale)
    {
        var newItem = Instantiate(FieldItemGo, position, Quaternion.identity);
        newItem.GetComponentInChildren<SpriteRenderer>().sprite = image;
        newItem.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(scale, scale, 1);
    }
}
