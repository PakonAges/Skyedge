using System.Collections.Generic;

public class MatchChecker : IMatchChecker
{
    public Field GameField { get; set; }
    List<Chip> _horizontalChips = new List<Chip>();
    List<Chip> _verticalChips = new List<Chip>();
    List<Chip> _matchinngChips = new List<Chip>();

    public List<Chip> GetMatch(Chip chip, int newX, int newY)
    {
        CleanUp();

        if (chip.IsColored)
        {
            NormalChipType chipColor = chip.NormalChipType;
            if (!CheckHorizontal(chip, chipColor, newX, newY)) //Didn't find horizontaly
            {
                CheckVertical(chip, chipColor, newX, newY);
            }
            //Don't forget to initialize = get field ref + install checkker + add checking after
            return _matchinngChips;
        }

        return null;
    }

    private bool CheckHorizontal(Chip chip, NormalChipType color, int newX, int newY)
    {
        _horizontalChips.Add(chip);

        //dir 0 = left, 1 = right
        for (int dir = 0; dir <= 1; dir++)
        {
            for (int xOffset = 1; xOffset < GameField.Xsize; xOffset++)
            {
                int x;

                if (dir == 0)
                {
                    x = newX - xOffset;
                }
                else
                {
                    x = newX + xOffset;
                }

                if (x < 0 || x >= GameField.Xsize)
                {
                    break;
                }

                if (GameField.FieldMatrix[x,newY].IsColored && GameField.FieldMatrix[x,newY].NormalChipType == color)
                {
                    _horizontalChips.Add(GameField.FieldMatrix[x, newY]);
                }
                else
                {
                    break;
                }
            }
        }

        if (_horizontalChips.Count >= 3)
        {
            for (int i = 0; i < _horizontalChips.Count; i++)
            {
                _matchinngChips.Add(_horizontalChips[i]);
            }
        }

        if (_matchinngChips.Count >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckVertical(Chip chip, NormalChipType color, int newX, int newY)
    {
        _verticalChips.Add(chip);

        //dir 0 = Up, 1 = Down
        for (int dir = 0; dir <= 1; dir++)
        {
            for (int yOffset = 1; yOffset < GameField.Ysize; yOffset++)
            {
                int y;

                if (dir == 0)
                {
                    y = newY - yOffset;
                }
                else
                {
                    y = newY + yOffset;
                }

                if (y < 0 || y >= GameField.Ysize)
                {
                    break;
                }

                if (GameField.FieldMatrix[newX, y].IsColored && GameField.FieldMatrix[newX, y].NormalChipType == color)
                {
                    _verticalChips.Add(GameField.FieldMatrix[newX, y]);
                }
                else
                {
                    break;
                }
            }
        }

        if (_verticalChips.Count >= 3)
        {
            for (int i = 0; i < _verticalChips.Count; i++)
            {
                _matchinngChips.Add(_verticalChips[i]);
            }
        }

        if (_matchinngChips.Count >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void CleanUp()
    {
        _horizontalChips.Clear();
        _verticalChips.Clear();
        _matchinngChips.Clear();
    }
}
