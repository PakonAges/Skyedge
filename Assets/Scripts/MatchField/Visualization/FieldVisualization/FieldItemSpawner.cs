using UnityEngine;

public class FieldItemSpawner : MonoBehaviour, IFieldItemSpawner
{
    public void CreateItem(Sprite image, Vector3 position)
    {
        Instantiate(image, position, Quaternion.identity);
    }
}
