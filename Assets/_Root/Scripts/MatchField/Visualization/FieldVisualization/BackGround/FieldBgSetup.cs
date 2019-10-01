using UnityEngine;
using Zenject;

public class FieldBgSetup : IFieldBGSetup,  IInitializable
{
    readonly IFieldBGScaleProvider _scaleProvider;
    readonly IFieldGridGenerator _fieldGridGenerator;
    readonly FieldGenerationRules _fieldGenerationRules;
    GameObject _backGroundGO;

    public FieldBgSetup(IFieldBGScaleProvider fieldBGScaleProvider,
                        IFieldGridGenerator fieldGridGenerator,
                        IFieldGenerationRulesProvider fieldGenerationRulesProvider,
                        GameObject bg)
    {
        _scaleProvider = fieldBGScaleProvider;
        _fieldGridGenerator = fieldGridGenerator;
        _backGroundGO = bg;
        _fieldGenerationRules = fieldGenerationRulesProvider.GetGenerationRules();

    }

    public void Initialize()
    {
        SetupBackGround();
    }

    public void SetupBackGround()
    {
        if (_backGroundGO == null)
        {
            Debug.LogErrorFormat("Didn't receive BG prefab: ",_backGroundGO);
        }

        var sr = _backGroundGO.GetComponentInChildren<SpriteRenderer>();

        if (sr != null)
        {
            sr.sprite = _fieldGenerationRules.BackgroundImage;
            sr.transform.localScale = Vector2.one * _scaleProvider.CalculateBGScale(_fieldGenerationRules.BackgroundImage.bounds.size.x, _fieldGenerationRules.BackgroundImage.bounds.size.y);
        }
        else
        {
            Debug.LogErrorFormat("Can't Find SpriteRenderer Component in BG prefab ({0})", _backGroundGO);
        }

        ShowEmptyGrid();
    }

    void ShowEmptyGrid()
    {
        _fieldGridGenerator.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }
}
