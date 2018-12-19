using System;
using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipSpriteChanger _chipSpriteChanger;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipVisualProvider _chipVisualProvider;
    readonly IChipSpawner _chipSpawner;
    readonly IFieldBGScaleProvider _fieldBGScaleProvider;
    readonly FieldVisualizationParameters _visualizationParameters;
    readonly Camera _mainCamera;

    GameObject _backGround;

    public DefaultFieldVisualization(   IChipPositionProvider fieldItemWorldPositionProvider,
                                        IChipSpriteChanger chipSpriteChanger,
                                        IChipPrefabProvider chipPrefabProvider,
                                        IChipVisualProvider fieldItemVisualProvider,
                                        IChipSpawner fieldItemSpawner,
                                        IFieldBGScaleProvider fieldBGScaleProvider,
                                        FieldVisualizationParameters fieldVisualizationParameters,
                                        Camera camera)
    {
        _chipPositioner = fieldItemWorldPositionProvider;
        _chipSpriteChanger = chipSpriteChanger;
        _chipPrefabProvider = chipPrefabProvider;
        _chipVisualProvider = fieldItemVisualProvider;
        _chipSpawner = fieldItemSpawner;
        _fieldBGScaleProvider = fieldBGScaleProvider;
        _visualizationParameters = fieldVisualizationParameters;
        _mainCamera = camera;
    }

    public void ShowField(Field fieldData)
    {
        float _chipSize = _chipPositioner.CalculateChipSize(fieldData.Xsize, fieldData.Ysize);

        for (int x = 0; x < fieldData.Xsize; x++)
        {
            for (int y = 0; y < fieldData.Ysize; y++)
            {
                var pos = _chipPositioner.GetPosition(x, y);
                var prefab = _chipPrefabProvider.GetPrefab(fieldData.FieldMatrix[x, y].ChipType);
                prefab.name = "Chip [" + x + ";" + y + "]";
                //prefab.transform.parent = _fieldBackGround.transform;
                _chipSpawner.SpawnChip(prefab, pos, _chipSize);
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
        _backGround = _chipSpawner.SpawnChip(_visualizationParameters.Background, Vector3.zero, _fieldBGScaleProvider.CalculateBGScale(_mainCamera, image));
        var sr = _backGround.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = image;
    }

    public void ShowEmptyGrid(int Xsize, int Ysize)
    {
        float _chipSize = _chipPositioner.CalculateChipSize(Xsize, Ysize);

        for (int x = 0; x < Xsize; x++)
        {
            for (int y = 0; y < Ysize; y++)
            {
                var pos = _chipPositioner.GetPosition(x, y);
                var cell = _chipSpawner.SpawnChip(_visualizationParameters.GridCell, pos, _chipSize);
                cell.name = "Cell[" + x + ";" + y + "]";
                cell.transform.parent = _backGround.transform;

                //change sprite to make chessboard-like
                if (IsOdd(x,y))
                {
                    _chipSpriteChanger.ChangeImage(cell, _visualizationParameters.DarkCellBg);
                }
                else
                {
                    _chipSpriteChanger.ChangeImage(cell, _visualizationParameters.LightCellBg);
                }
                
            }
        }
    }

    bool IsOdd(int x, int y)
    {
        return (x + y) % 2 != 0;
    }
}
