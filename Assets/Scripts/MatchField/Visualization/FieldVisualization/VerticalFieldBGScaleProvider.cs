using UnityEngine;

public class VerticalFieldBGScaleProvider : IFieldBGScaleProvider
{
    public float CalculateBGScale(Camera cam, Sprite image)
    {
        var width = image.bounds.size.x;
        var height = image.bounds.size.y;

        var worldScreenHeight = cam.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float scaleX = (float) worldScreenWidth / width;
        float scaleY = (float) worldScreenHeight / height;

        return (scaleX > scaleY) ? scaleX : scaleY;
    }
}
