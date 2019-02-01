﻿using System;
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
    List<ColorChip> _matches;

    public FIeldCleaner(IChipManager chipManager,
                        IMatchChecker matchChecker,
                        IFieldFiller fieldFiller)
    {
        _chipManager = chipManager;
        _matchChecker = matchChecker;
        _fieldFiller = fieldFiller;
        _matches = new List<ColorChip>();
    }

    public async Task ClearAndRefillBoardAsync()
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
                if (GameField.FieldMatrix[x, y].IsClearable)
                {
                    _matches = _matchChecker.GetMatch(GameField.FieldMatrix[x, y]);

                    if (_matches != null && _matches.Any())
                    {
                        for (int i = 0; i < _matches.Count; i++)
                        {
                            try
                            {
                                if (await ClearChipAsync(_matches[i].X, _matches[i].Y))
                                {
                                    needsRefill = true;
                                }
                            }
                            catch (Exception e)
                            {
                                Debug.LogErrorFormat("AHTUNG: {0}", e);
                                Debug.LogErrorFormat("Trying to Clear Chip {0}", _matches[i]);
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
            try
            {
                RemoveChip(GameField.FieldMatrix[x, y]);
                GameField.FieldMatrix[x, y] = _chipManager.SpawnEmptyChip(x, y);
                await new WaitForEndOfFrame();
                return true;
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("AHTUNG: {0}", e);
                Debug.LogErrorFormat("Trying to clear Chip {0}", GameField.FieldMatrix[x, y]);
            }
            return false;

        }
        else
        {
            return false;
        }
    }

    void RemoveChip(IChip chip)
    {
        _chipManager.RemoveChip(chip);
    }

    public void ChangeFillDirection(int chip1_x, int chip1_y, int chip2_x, int chip2_y)
    {
        if (chip1_x == chip2_x && chip1_y < chip2_y)
        {
            _fieldFiller.FillDirection = MoveDirection.TopToBot;

        }
        else if (chip1_x == chip2_x && chip1_y > chip2_y)
        {
            _fieldFiller.FillDirection = MoveDirection.BotToTop;
        }
        else if (chip1_x < chip2_x && chip1_y == chip2_y)
        {
            _fieldFiller.FillDirection = MoveDirection.LeftToRight;
        }
        else if (chip1_x > chip2_x && chip1_y == chip2_y)
        {
            _fieldFiller.FillDirection = MoveDirection.RightToLeft;
        }
        else
        {
            Debug.LogErrorFormat("Can't Detect Fill Direction with chip1[{0};{1}] and chip2[{2};{3}]", chip1_x, chip1_y, chip2_x, chip2_y);
        }
    }

    public void ChangeFillDirection(MoveDirection moveDirection)
    {
        _fieldFiller.FillDirection = moveDirection;
    }

    public async Task ClearChipAndRefillAsync(int x, int y)
    {
        try
        {
            await ClearChipAsync(x, y);
            await _fieldFiller.FullFillAsync();
            await ClearAndRefillBoardAsync();
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to clear one Chip and refill");
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