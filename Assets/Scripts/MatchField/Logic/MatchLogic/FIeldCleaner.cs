using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

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

    public async void ClearAndRefillBoard()
    {
        bool NeedsToRefill = await ClearAllMathcesAndNeedsToRefillAsync();

        while (NeedsToRefill)
        //if (NeedsToRefill)
        {
            await _fieldFiller.FullFillAsync();
            NeedsToRefill = await ClearAllMathcesAndNeedsToRefillAsync();
        }
    }

    public async Task<bool> ClearAllMathcesAndNeedsToRefillAsync()
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

                    if (_matches != null && _matches.Any())
                    {
                        for (int i = 0; i < _matches.Count; i++)
                        {
                            if (await ClearChipAsync(_matches[i].X, _matches[i].Y))
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

    public async Task<bool> ClearChipAsync(int x, int y)
    {
        if (GameField.FieldMatrix[x, y].IsClearable) //check for isBeingCleared?
        {
            RemoveChip(GameField.FieldMatrix[x, y]);
            _chipManager.SpawnEmptyChip(x, y);
            await new WaitForEndOfFrame();
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
