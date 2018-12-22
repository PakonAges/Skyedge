using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldGridGenerator : IFieldGridGenerator
{
    readonly FieldVisualizationParameters _visualizationParameters;
    readonly GridCell.Factory _gridCellFactory;
    readonly IChipPositionProvider _chipPositionProvider;

    Scene _gridScene;

    [Serializable]
    public class Settings
    {
        //public GameObject AsteroidPrefab;
    }

    public FieldGridGenerator(  FieldVisualizationParameters fieldVisualizationParameters,
                                GridCell.Factory cellFactory,
                                IChipPositionProvider chipPositionProvider)
    {
        _visualizationParameters = fieldVisualizationParameters;
        _gridCellFactory = cellFactory;
        _chipPositionProvider = chipPositionProvider;

        _gridScene = SceneManager.CreateScene("Grid");
    }

    public void ShowEmptyGrid(int Xsize, int Ysize)
    {
        for (int x = 0; x < Xsize; x++)
        {
            for (int y = 0; y < Ysize; y++)
            {
                var newCell = _gridCellFactory.Create();
                newCell.name = "Cell[" + x + ";" + y + "]";
                newCell.Scale = _chipPositionProvider.ChipSize;
                newCell.Position = _chipPositionProvider.GetPosition(x, y);
                newCell.Image = GetChestLikeSprite(x, y);
                SceneManager.MoveGameObjectToScene(newCell.gameObject, _gridScene);
            }
        }
    }

    private Sprite GetChestLikeSprite(int x, int y)
    {
        if (IsOdd(x, y))
        {
            return _visualizationParameters.DarkCellBg;
        }
        else
        {
           return _visualizationParameters.LightCellBg;
        }
    }

    bool IsOdd(int x, int y)
    {
        return (x + y) % 2 != 0;
    }
}
