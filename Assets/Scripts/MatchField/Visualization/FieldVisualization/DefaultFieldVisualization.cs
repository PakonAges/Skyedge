using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IChipPositionProvider _itemPositioner;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipVisualProvider _fieldItemVisualProvider;
    readonly IChipSpawner _fieldItemSpawner;
    readonly IFieldBGScaleProvider _fieldBGScaleProvider;

    private GameObject _fieldBackGround;
    readonly Camera _mainCamera;

    public DefaultFieldVisualization(   IChipPositionProvider fieldItemWorldPositionProvider,
                                        IChipPrefabProvider chipPrefabProvider,
                                        IChipVisualProvider fieldItemVisualProvider,
                                        IChipSpawner fieldItemSpawner,
                                        IFieldBGScaleProvider fieldBGScaleProvider,
                                        Camera camera)
    {
        _itemPositioner = fieldItemWorldPositionProvider;
        _chipPrefabProvider = chipPrefabProvider;
        _fieldItemVisualProvider = fieldItemVisualProvider;
        _fieldItemSpawner = fieldItemSpawner;
        _fieldBGScaleProvider = fieldBGScaleProvider;
        _mainCamera = camera;
    }

    public void ShowField(Field fieldData)
    {
        float ItemSize = _itemPositioner.CalculateItemSize(_mainCamera, fieldData.Xsize, fieldData.Ysize);

        for (int x = 0; x < fieldData.Xsize; x++)
        {
            for (int y = 0; y < fieldData.Ysize; y++)
            {
                var pos = _itemPositioner.GetPosition(x, y);
                var prefab = _chipPrefabProvider.GetPrefab(fieldData.FieldMatrix[x, y].ChipType);
                prefab.name = "Chip [" + x + ";" + y + "]";
                //prefab.transform.parent = _fieldBackGround.transform;
                _fieldItemSpawner.SpawnChip(prefab, pos, ItemSize);
            }
        }

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(Field fieldData)
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
