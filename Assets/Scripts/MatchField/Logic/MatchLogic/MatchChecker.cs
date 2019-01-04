using System.Collections.Generic;

public class MatchChecker : IMatchChecker
{
    public Field GameField { get; set; }
    List<Chip> _horizontalChips = new List<Chip>();
    List<Chip> _verticalChips = new List<Chip>();
    List<Chip> _matchingChips = new List<Chip>();

    public List<Chip> GetMatch(Chip chip, int newX, int newY)
    {
        CleanUp();

        if (chip.IsColored)
        {
            NormalChipType color = chip.NormalChipType;

            //Check Horizontal
            _horizontalChips.Add(chip);

            for (int dir = 0; dir <= 1; dir++)
            {
                for (int xOffset = 1; xOffset < GameField.Xsize; xOffset++)
                {
                    int x;

                    //Left dir
                    if (dir == 0)   { x = newX - xOffset; }
                    //Right dir
                    else            { x = newX + xOffset; }
                    if (x < 0 || x >= GameField.Xsize) break;

                    if (GameField.FieldMatrix[x, newY].IsColored && GameField.FieldMatrix[x, newY].NormalChipType == color)
                    {
                        _horizontalChips.Add(GameField.FieldMatrix[x, newY]);
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
                            if (dir == 0) { y = newY - yOffset; }
                            //Down
                            else { y = newY + yOffset; }
                            if (y < 0 || y >= GameField.Ysize) break;

                            if (GameField.FieldMatrix[_horizontalChips[i].X, y].IsColored && GameField.FieldMatrix[_horizontalChips[i].X, y].NormalChipType == color)
                            {
                                _verticalChips.Add(GameField.FieldMatrix[_horizontalChips[i].X, y]);
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
                UnityEngine.Debug.LogFormat("Found {0} chips in HORIZONTAL combo", _matchingChips.Count);
                return _matchingChips;
            }

            // Didn't find anything going horizontally first,
            // so now check vertically
            _horizontalChips.Clear();
            _verticalChips.Clear();
            _verticalChips.Add(chip);

            //dir 0 = Up, 1 = Down
            for (int dir = 0; dir <= 1; dir++)
            {
                for (int yOffset = 1; yOffset < GameField.Ysize; yOffset++)
                {
                    int y;

                    if (dir == 0) { y = newY - yOffset; }
                    else { y = newY + yOffset; }
                    if (y < 0 || y >= GameField.Ysize) break;

                    if (GameField.FieldMatrix[newX, y].IsColored && GameField.FieldMatrix[newX, y].NormalChipType == color)
                    {
                        _verticalChips.Add(GameField.FieldMatrix[newX, y]);
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
                            if (dir == 0) { x = newX - xOffset; }
                            //Right
                            else { x = newX + xOffset; }
                            if (x < 0 || x >= GameField.Xsize) break;

                            if (GameField.FieldMatrix[x, _verticalChips[i].Y].IsColored && GameField.FieldMatrix[x, _verticalChips[i].Y].NormalChipType == color)
                            {
                                _horizontalChips.Add(GameField.FieldMatrix[x, _verticalChips[i].Y]);
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
                UnityEngine.Debug.LogFormat("Found {0} chips in VERTICAL combo",_matchingChips.Count);
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
