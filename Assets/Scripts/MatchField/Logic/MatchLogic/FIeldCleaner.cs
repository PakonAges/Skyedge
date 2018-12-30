using System.Collections.Generic;

public class FIeldCleaner : IFieldCleaner
{
    public Field GameField { get; set; }
    readonly IChipSpawner _chipSpawner;
    readonly IMatchChecker _matchChecker;
    List<Chip> _matches;

    public FIeldCleaner(IChipSpawner chipSpawner,
                        IMatchChecker matchChecker)
    {
        _chipSpawner = chipSpawner;
        _matchChecker = matchChecker;
        _matches = new List<Chip>();
    }

    public bool ClearAllValidMathces()
    {
        bool needsRefill = false;
        _matches.Clear();

        for (int y = 0; y < GameField.Ysize; y++)
        {
            for (int x = 0; x < GameField.Xsize; x++)
            {
                if (GameField.FieldMatrix[x,y].IsClearable)
                {
                    _matches = _matchChecker.GetMatch(GameField.FieldMatrix[x, y], x, y);

                    if (_matches != null)
                    {
                        for (int i = 0; i < _matches.Count; i++)
                        {
                            if (ClearChip(_matches[i].X, _matches[i].Y))
                            {
                                needsRefill = true;
                            }
                        }
                    }
                }
            }
        }

        return needsRefill;
    }

    public bool ClearChip(int x, int y)
    {
        if (GameField.FieldMatrix[x, y].IsClearable) //check for isBeingCleared?
        {
            RemoveChip(GameField.FieldMatrix[x, y]);
            _chipSpawner.SpawnEmptyChip(x, y);
            return true;
        }
        else
        {
            return false;
        }
    }

    void RemoveChip(Chip chip)
    {
        chip.gameObject.SetActive(false);
    }
}
