using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IFieldItemPositionProvider _itemPositioner;
    readonly IFieldItemVisualProvider _fieldItemVisualProvider;
    readonly IFieldItemSpawner _fieldItemSpawner;
    readonly IFieldBGScaleProvider _fieldBGScaleProvider;

    private GameObject _fieldBackGround;
    readonly Camera _mainCamera;

    public DefaultFieldVisualization(   IFieldItemPositionProvider fieldItemWorldPositionProvider,
                                        IFieldItemVisualProvider fieldItemVisualProvider,
                                        IFieldItemSpawner fieldItemSpawner,
                                        IFieldBGScaleProvider fieldBGScaleProvider,
                                        Camera camera)
    {
        _itemPositioner = fieldItemWorldPositionProvider;
        _fieldItemVisualProvider = fieldItemVisualProvider;
        _fieldItemSpawner = fieldItemSpawner;
        _fieldBGScaleProvider = fieldBGScaleProvider;
        _mainCamera = camera;
    }

    public void ShowField(FieldData fieldData)
    {
        float ItemSize = _itemPositioner.CalculateItemSize(_mainCamera, fieldData.Xsize, fieldData.Ysize);

        for (int i = 0; i < fieldData.Ysize; i++)
        {
            for (int j = 0; j < fieldData.Xsize; j++)
            {
                var pos = _itemPositioner.GetPosition(i, j);
                var img = _fieldItemVisualProvider.GetItemSprite((FieldItemType)fieldData.FieldMatrix[i,j]);
                _fieldItemSpawner.CreateItem(img, pos, ItemSize);
            }
        }

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(FieldData fieldData)
    {
        //Way to reset? clear all!
        Debug.Log("Field Resetted from field visualization");
    }

    public void ShowBackGround(Sprite image)
    {
        _fieldBackGround = new GameObject("BackGround");
        var sr = _fieldBackGround.AddComponent<SpriteRenderer>();
        sr.sprite = image;
        sr.sortingLayerName = "BackGround";

        float BgScale = _fieldBGScaleProvider.CalculateBGScale(_mainCamera, image);

        _fieldBackGround.transform.localScale = new Vector3(BgScale,BgScale,1);
    }
}
