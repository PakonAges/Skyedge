using System.Collections.Generic;

public class MatchChecker : IMatchChecker
{
    readonly IChipInfoService _chipServise;
    readonly IFieldDataProvider _fieldDataProvider;

    private Field GameField;
    List<ColorChip> _horizontalChips = new List<ColorChip>();
    List<ColorChip> _verticalChips = new List<ColorChip>();
    List<ColorChip> _matchingChips = new List<ColorChip>();

    public MatchChecker (   IChipInfoService chipComparer,
                            IFieldDataProvider fieldDataProvider)
    {
        _chipServise = chipComparer;
        _fieldDataProvider = fieldDataProvider;
    }

    public List<ColorChip> GetMatch(IChip chip)
    {
        GameField = _fieldDataProvider.GameField;
        CleanUp();

        if (chip.ChipType == ChipType.ColorChip)
        {
            ChipColor color = _chipServise.GetTypeData<ColorChip>(chip).Color;

            //Check Horizontal
            _horizontalChips.Add(_chipServise.GetTypeData<ColorChip>(chip));

            for (int dir = 0; dir <= 1; dir++)
            {
                for (int xOffset = 1; xOffset < GameField.Xsize; xOffset++)
                {
                    int x;

                    //Left dir
                    if (dir == 0)   { x = chip.X - xOffset; }
                    //Right dir
                    else            { x = chip.X + xOffset; }
                    if (x < 0 || x >= GameField.Xsize) break;

                    if (_chipServise.IsColored(GameField.FieldMatrix[x, chip.Y],color))
                    {
                        _horizontalChips.Add(_chipServise.GetTypeData<ColorChip>(GameField.FieldMatrix[x, chip.Y]));
                    }
                    else break;
                }
            }

            //Add Line Match
            if (_horizontalChips.Count >= 3)
            {
                for (int i = 0; i < _horizontalChips.Count; i++)
                {
                    _matchingChips.Add(_horizontalChips[i]);
                }
            }

            //Check for L-shape and T-shape
            if (_horizontalChips.Count >= 3)
            {
                for (int i = 0; i < _horizontalChips.Count; i++)
                {
                    for (int dir = 0; dir <= 1; dir++)
                    {
                        for (int yOffset = 1; yOffset < GameField.Ysize; yOffset++)
                        {
                            int y;

                            //Up
                            if (dir == 0) { y = chip.Y - yOffset; }
                            //Down
                            else { y = chip.Y + yOffset; }
                            if (y < 0 || y >= GameField.Ysize) break;

                            if (_chipServise.IsColored(GameField.FieldMatrix[_horizontalChips[i].X, y], color))
                            {
                                _verticalChips.Add(_chipServise.GetTypeData<ColorChip>(GameField.FieldMatrix[_horizontalChips[i].X, y]));
                            }
                            else break;
                        }
                    }

                    if (_verticalChips.Count < 2)
                    {
                        _verticalChips.Clear();
                    }
                    else
                    {
                        for (int j = 0; j < _verticalChips.Count; j++)
                        {
                            _matchingChips.Add(_verticalChips[j]);
                        }
                        break;
                    }
                }
            }

            if (_matchingChips.Count >= 3)
            {
                //UnityEngine.Debug.LogFormat("Found {0} chips in HORIZONTAL combo", _matchingChips.Count);
                return _matchingChips;
            }

            // Didn't find anything going horizontally first,
            // so now check vertically
            _horizontalChips.Clear();
            _verticalChips.Clear();
            _verticalChips.Add(_chipServise.GetTypeData<ColorChip>(chip));

            //dir 0 = Up, 1 = Down
            for (int dir = 0; dir <= 1; dir++)
            {
                for (int yOffset = 1; yOffset < GameField.Ysize; yOffset++)
                {
                    int y;

                    if (dir == 0) { y = chip.Y - yOffset; }
                    else { y = chip.Y + yOffset; }
                    if (y < 0 || y >= GameField.Ysize) break;

                    if(_chipServise.IsColored(GameField.FieldMatrix[chip.X, y],color))
                    {
                        _verticalChips.Add(_chipServise.GetTypeData<ColorChip>(GameField.FieldMatrix[chip.X, y]));
                    }
                    else break;
                }
            }

            if (_verticalChips.Count >= 3)
            {
                for (int i = 0; i < _verticalChips.Count; i++)
                {
                    _matchingChips.Add(_verticalChips[i]);
                }
            }

            // Traverse horizontally if we found a match (for L and T shapes)
            if (_verticalChips.Count >= 3)
            {
                for (int i = 0; i < _verticalChips.Count; i++)
                {
                    for (int dir = 0; dir <= 1; dir++)
                    {
                        for (int xOffset = 1; xOffset < GameField.Xsize; xOffset++)
                        {
                            int x;
                            //left
                            if (dir == 0) { x = chip.X - xOffset; }
                            //Right
                            else { x = chip.X + xOffset; }
                            if (x < 0 || x >= GameField.Xsize) break;

                            if(_chipServise.IsColored(GameField.FieldMatrix[x, _verticalChips[i].Y],color))
                            {
                                _horizontalChips.Add(_chipServise.GetTypeData<ColorChip>(GameField.FieldMatrix[x, _verticalChips[i].Y]));
                            }
                            else break;
                        }
                    }

                    if (_horizontalChips.Count < 2)
                    {
                        _horizontalChips.Clear();
                    }
                    else
                    {
                        for (int j = 0; j < _horizontalChips.Count; j++)
                        {
                            _matchingChips.Add(_horizontalChips[j]);
                        }
                        break;
                    }
                }
            }

            if (_matchingChips.Count >= 3)
            {
                //UnityEngine.Debug.LogFormat("Found {0} chips in VERTICAL combo",_matchingChips.Count);
                return _matchingChips;
            }
        }

        CleanUp();
        return _matchingChips;
    }

    private void CleanUp()
    {
        _horizontalChips.Clear();
        _verticalChips.Clear();
        _matchingChips.Clear();
    }
}
