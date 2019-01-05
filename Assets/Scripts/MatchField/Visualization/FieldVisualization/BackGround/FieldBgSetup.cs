using UnityEngine;

public class FieldBgSetup : IFieldBGSetup
{
    readonly IFieldBGScaleProvider _scaleProvider;
    readonly IFieldGridGenerator _fieldGridGenerator;
    GameObject _backGroundGO;

    public FieldBgSetup(IFieldBGScaleProvider fieldBGScaleProvider,
                        IFieldGridGenerator fieldGridGenerator,
                        GameObject bg)
    {
        _scaleProvider = fieldBGScaleProvider;
        _fieldGridGenerator = fieldGridGenerator;
        _backGroundGO = bg;
    }

    public void SetupBackGround(Sprite bgImage)
    {
        if (_backGroundGO == null)
        {
            Debug.LogErrorFormat("Didn't receive BG prefab: ",_backGroundGO);
        }

        var sr = _backGroundGO.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = bgImage;
        sr.transform.localScale = Vector2.one * _scaleProvider.CalculateBGScale(bgImage);
    }

    public void ShowEmptyGrid(int FieldSizeX, int FieldSizeY)
    {
        _fieldGridGenerator.ShowEmptyGrid(FieldSizeX, FieldSizeY);
    }
}
