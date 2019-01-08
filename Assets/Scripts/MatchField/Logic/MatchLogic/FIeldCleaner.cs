using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class FIeldCleaner : IFieldCleaner
{
    public Field GameField { get; set; }
    readonly IChipManager _colorChipManager;
    readonly IMatchChecker _matchChecker;
    readonly IFieldFiller _fieldFiller;
    List<ColorChip> _matches;

    public FIeldCleaner(IChipManager chipManager,
                        IMatchChecker matchChecker,
                        IFieldFiller fieldFiller)
    {
        _colorChipManager = chipManager;
        _matchChecker = matchChecker;
        _fieldFiller = fieldFiller;
        _matches = new List<ColorChip>();
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
                    _matches = _matchChecker.GetMatch(GameField.FieldMatrix[x, y]);

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
            _colorChipManager.SpawnEmptyChip(x, y);
            await new WaitForEndOfFrame();
            return true;
        }
        else
        {
            return false;
        }
    }

    void RemoveChip(IChip chip)
    {
        switch (chip.ChipType)
        {
            case ChipType.ColorChip:
            _colorChipManager.RemoveChip(chip.MyGo.GetComponent<Chip>());
            break;

            case ChipType.EmptyCell:
            break;

            case ChipType.Hero:
            break;

            case ChipType.Enemy:
            break;

            default:
            break;
        }
    }

    public void ChangeFillDirection(int chip1_x, int chip1_y, int chip2_x, int chip2_y)
    {
        if (chip1_x == chip2_x && chip1_y < chip2_y)
        {
            _fieldFiller.FillDirection = FieldFillDirection.TopToBot;

        }
        else if (chip1_x == chip2_x && chip1_y > chip2_y)
        {
            _fieldFiller.FillDirection = FieldFillDirection.BotToTop;
        }
        else if (chip1_x < chip2_x && chip1_y == chip2_y)
        {
            _fieldFiller.FillDirection = FieldFillDirection.LeftToRight;
        }
        else if (chip1_x > chip2_x && chip1_y == chip2_y)
        {
            _fieldFiller.FillDirection = FieldFillDirection.RightToLeft;
        }
        else
        {
            Debug.LogErrorFormat("Can't Detect Fill Direction with chip1[{0};{1}] and chip2[{2};{3}]", chip1_x, chip1_y, chip2_x, chip2_y);
        }
    }

    public void ClearAllBoard()
    {
        for (int y = 0; y < GameField.Ysize; y++)
        {
            for (int x = 0; x < GameField.Xsize; x++)
            {
                RemoveChip(GameField.FieldMatrix[x, y]);
            }
        }
    }
}
