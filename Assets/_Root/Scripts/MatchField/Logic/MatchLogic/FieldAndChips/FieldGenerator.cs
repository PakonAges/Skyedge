﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Generates Match Field and Fills it with Color chips, according to the Generation Rules. Without Combos
/// </summary>
public class FieldGenerator : IFieldGenerator
{
    readonly IChipManager _chipManager;
    readonly IChipInfoService _chipComparer;
    readonly IFieldDataProvider _fieldDataHolder;

    public FieldGenerator ( IChipManager chipManager,
                            IChipInfoService chipComparer,
                            IFieldDataProvider fieldDataProvider)
    {
        _chipManager = chipManager;
        _chipComparer = chipComparer;
        _fieldDataHolder = fieldDataProvider;
    }

    public async Task<Field> GenerateAndShowFieldAsync(FieldGenerationRules rules)
    {
        try
        {
            var NewField = new Field(rules.Xsize, rules.Ysize);

            for (int x = 0; x < rules.Xsize; x++)
            {
                for (int y = 0; y < rules.Ysize; y++)
                {
                    if (NewField.FieldMatrix[x,y] == null)
                    {
                        ChipColor type = GetTypeWithoutMatches(NewField, x, y);
                        NewField.FieldMatrix[x, y] = _chipManager.SpawnColorChip(type, x, y);
                    }
                }
            }

            //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);
            await new WaitForEndOfFrame();

            _fieldDataHolder.GameField = NewField;
            return NewField;

        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }

    ChipColor GetTypeWithoutMatches(Field field, int x, int y)
    {
        var Color = GetRandomColor();

        if (x < 2 && y < 2)
        {
            return Color;
        }
        else
        {
            if (HasMatchNeedsToChange(field, Color, x, y))
            {
                var newType = NewTypeWithout(Color);

                if (HasMatchNeedsToChange(field, newType, x, y))
                {
                    return NewColorWithout(Color, newType);
                }
                else
                {
                    return newType;
                }
            }
            else
            {
                return Color;
            }
        }
    }

    bool HasMatchNeedsToChange(Field field, ChipColor color, int x, int y)
    {
        /// The board is filled from Left to Right, and from Top to Bottom.
        /// So I need to check only chips to the left and above new Chip for combos.
        /// And I can skip first 2 chips 

        if (x >= 2)
        {
            if (_chipComparer.IsColored(field.FieldMatrix[x - 1, y], color) && _chipComparer.IsColored(field.FieldMatrix[x - 2, y], color))
            {
                return true;
            }
        }

        //check top
        if (y >= 2)
        {
            if (_chipComparer.IsColored(field.FieldMatrix[x, y - 1], color) && _chipComparer.IsColored(field.FieldMatrix[x, y - 2], color))
            {
                return true;
            }
        }

        return false;        
    }

    ChipColor NewTypeWithout(ChipColor bannedColor)
    {
        List<ChipColor> possibleColors = new List<ChipColor>();

        //foreach (NormalChipType t in (NormalChipType[])Enum.GetValues(typeof(NormalChipType)))
        foreach (ChipColor t in Enum.GetValues(typeof(ChipColor)))
        {
            if (t != bannedColor)
            {
                if (t != ChipColor.Total)
                {
                    possibleColors.Add(t);
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleColors.Count);
        return possibleColors[i];
    }

    ChipColor NewColorWithout(ChipColor color, ChipColor newColor)
    {
        List<ChipColor> possibleColors = new List<ChipColor>();

        foreach (ChipColor t in Enum.GetValues(typeof(ChipColor)))
        {
            if (t != color)
            {
                if (t != newColor)
                {
                    if (t != ChipColor.Total)
                    {
                        possibleColors.Add(t);
                    }
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleColors.Count);
        return possibleColors[i];
    }

    ChipColor GetRandomColor()
    {
        return (ChipColor)UnityEngine.Random.Range(0, (int)ChipColor.Total);
    }
}
