using UnityEngine;

public class FieldBgSetup : IFieldBGSetup
{
    readonly IFieldBGScaleProvider _scaleProvider;
    GameObject _backGroundGO;

    public FieldBgSetup(IFieldBGScaleProvider fieldBGScaleProvider,
                        GameObject bg)
    {
        _scaleProvider = fieldBGScaleProvider;
        _backGroundGO = bg;
    }

    public void SetupBackGround(Sprite bgImage)
    {
        if (_backGroundGO == null)
        {
            Debug.LogErrorFormat("Didn't receive BG prefab: ",_backGroundGO);
            
            //Should Spawn!
        }

        var sr = _backGroundGO.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = bgImage;
        sr.transform.localScale = Vector2.one * _scaleProvider.CalculateBGScale(bgImage);
    }
}
