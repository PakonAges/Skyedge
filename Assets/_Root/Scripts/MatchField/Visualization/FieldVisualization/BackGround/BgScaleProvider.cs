using UnityEngine;

public class BgScaleProvider : IFieldBGScaleProvider
{
    readonly Camera _mainCam;

    public BgScaleProvider(Camera camera)
    {
        _mainCam = camera;
    }

    public float CalculateBGScale(float ImageWidth, float ImageHeight)
    {
        var worldScreenHeight = _mainCam.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float scaleX = (float) worldScreenWidth / ImageWidth;
        float scaleY = (float) worldScreenHeight / ImageHeight;

        return (scaleX > scaleY) ? scaleX : scaleY;
    }
}
