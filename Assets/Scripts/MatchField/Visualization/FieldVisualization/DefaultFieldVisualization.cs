using System;
using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipSpriteChanger _chipSpriteChanger;
    readonly IChipVisualProvider _chipVisualProvider;
    readonly IChipSpawner _chipSpawner;
    readonly IChipMovement _chipMovement;
    readonly FieldVisualizationParameters _visualizationParameters;

    public DefaultFieldVisualization(   
                                        IChipPositionProvider fieldItemWorldPositionProvider,
                                        IChipSpriteChanger chipSpriteChanger,
                                        IChipVisualProvider fieldItemVisualProvider,
                                        IChipSpawner fieldItemSpawner,
                                        IChipMovement chipMovement,
                                        FieldVisualizationParameters fieldVisualizationParameters)
    {
        _chipPositioner = fieldItemWorldPositionProvider;
        _chipSpriteChanger = chipSpriteChanger;
        _chipVisualProvider = fieldItemVisualProvider;
        _chipSpawner = fieldItemSpawner;
        _chipMovement = chipMovement;
        _visualizationParameters = fieldVisualizationParameters;
    }

    public void ShowField(Field fieldData)
    {
        float _chipSize = _chipPositioner.CalculateChipSize(fieldData.Xsize, fieldData.Ysize);

        for (int x = 0; x < fieldData.Xsize; x++)
        {
            for (int y = 0; y < fieldData.Ysize; y++)
            {
                var prefab = _chipPrefabProvider.GetPrefab(fieldData.FieldMatrix[x, y].ChipType);
                var ChipGO = _chipSpawner.SpawnChip(prefab, Vector3.zero, _chipSize);
                fieldData.FieldMatrix[x, y].ChipTransform = ChipGO.transform;
                ChipGO.name = "Chip [" + x + ";" + y + "]";

                _chipMovement.Move(fieldData.FieldMatrix[x, y], x, y);
            }
        }

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(Field fieldData)
    {
        //Way to reset? clear all!
        Debug.Log("Field Resetted from field visualization");
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
