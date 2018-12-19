using UnityEngine;

public class ChipSpriteChanger : IChipSpriteChanger
{
    public void ChangeImage(GameObject item, Sprite image)
    {
        var sr = item.GetComponentInChildren<SpriteRenderer>();
        if (sr)
        {
            sr.sprite = image;
        }
        else
        {
            Debug.LogErrorFormat("Can't find Sprite Renderer in Children of: {0}",item);
        }
    }
}
