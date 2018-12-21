using UnityEngine;

public class BgScaleProvider : IFieldBGScaleProvider
{
    readonly Camera _mainCam;

    public BgScaleProvider(Camera camera)
    {
        _mainCam = camera;
    }

    public float CalculateBGScale(Sprite image)
    {
        var width = image.bounds.size.x;
        var height = image.bounds.size.y;

        var worldScreenHeight = _mainCam.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float scaleX = (float) worldScreenWidth / width;
        float scaleY = (float) worldScreenHeight / height;

        return (scaleX > scaleY) ? scaleX : scaleY;
    }
}
