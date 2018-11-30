using UnityEngine;

public interface IFieldBGScaleProvider
{
    float CalculateBGScale(Camera cam, Sprite image);
}
