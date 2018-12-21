public class FieldGridGenerator : IFieldGridGenerator
{
    readonly FieldVisualizationParameters _visualizationParameters;
    readonly IChipSpawner _chipSpawner;

    public FieldGridGenerator(  FieldVisualizationParameters fieldVisualizationParameters,
                                IChipSpawner chipSpawner)
    {
        _visualizationParameters = fieldVisualizationParameters;
        _chipSpawner = chipSpawner;
    }

    public void ShowEmptyGrid(int Xsize, int Ysize)
    {
        for (int x = 0; x < Xsize; x++)
        {
            for (int y = 0; y < Ysize; y++)
            {
                _chipSpawner.SpawnChip();
                var pos = _chipPositionProvider.GetPosition(x, y);
                var cell = _chipSpawner.SpawnChip(_visualizationParameters.GridCell, pos, _chipSize);
                cell.name = "Cell[" + x + ";" + y + "]";
                cell.transform.parent = _backGround.transform;

                //change sprite to make chessboard-like
                if (IsOdd(x, y))
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
