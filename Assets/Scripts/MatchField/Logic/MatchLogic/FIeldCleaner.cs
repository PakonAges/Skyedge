using System.Collections.Generic;
using System.Linq;

public class FIeldCleaner : IFieldCleaner
{
    public Field GameField { get; set; }
    readonly IChipManager _chipManager;
    readonly IMatchChecker _matchChecker;
    readonly IFieldFiller _fieldFiller;
    List<Chip> _matches;

    public FIeldCleaner(IChipManager chipManager,
                        IMatchChecker matchChecker,
                        IFieldFiller fieldFiller)
    {
        _chipManager = chipManager;
        _matchChecker = matchChecker;
        _fieldFiller = fieldFiller;
        _matches = new List<Chip>();
    }

    public void ClearAndRefillBoard()
    {
        bool NeedsToRefill = ClearAllMathcesAndNeedsToRefill();

        //while (NeedsToRefill)
        if (NeedsToRefill)
        {
            _fieldFiller.FullFill();
            NeedsToRefill = ClearAllMathcesAndNeedsToRefill();
        }
    }

    public bool ClearAllMathcesAndNeedsToRefill()
    {
        bool needsRefill = false;
        _matches.Clear();

        //Nailed it! return null so erased my List. I'll keep it here for a while and see.

        //if (_matches != null) //Need to find why this hapeens? I tried to swap normal chips without combos. maybe some threading?async stUff?
        //{
        //    _matches.Clear();
        //}
        //else
        //{
        //    _matches = new List<Chip>();
        //    UnityEngine.Debug.LogFormat("Created new List {0}", _matches);
        //}

        for (int y = 0; y < GameField.Ysize; y++)
        {
            for (int x = 0; x < GameField.Xsize; x++)
            {
                if (GameField.FieldMatrix[x,y].IsClearable)
                {
                    _matches = _matchChecker.GetMatch(GameField.FieldMatrix[x, y], x, y);

                    if (_matches != null && _matches.Any())
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
            _chipManager.SpawnEmptyChip(x, y);
            return true;
        }
        else
        {
            return false;
        }
    }

    void RemoveChip(Chip chip)
    {
        _chipManager.RemoveChip(chip);
    }
}
