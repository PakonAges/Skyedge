using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FieldGenerator : IFieldGenerator
{
    readonly IChipManager _chipManager;
    
    public FieldGenerator (IChipManager chipManager)
    {
        _chipManager = chipManager;
    }

    public async Task<Field> GenerateFieldAsync(FieldGenerationRules rules)
    {
        var NewField = new Field(rules.Xsize, rules.Ysize);

        for (int x = 0; x < rules.Xsize; x++)
        {
            for (int y = 0; y < rules.Ysize; y++)
            {
                ChipColor type = GetTypeWithoutMatches(NewField, x, y);
                NewField.FieldMatrix[x, y] = _chipManager.SpawnNormalChip(type, x, y);
            }
        }

        //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);
        await new WaitForEndOfFrame();
        return NewField;
    }

    ChipColor GetTypeWithoutMatches(Field field, int x, int y)
    {
        var Type = GetRandomType();

        if (x < 2 && y < 2)
        {
            return Type;
        }
        else
        {
            if (HasMatchNeedsToChange(field, Type, x, y))
            {
                var newType = NewTypeWithout(Type);

                if (HasMatchNeedsToChange(field, newType, x, y))
                {
                    return NewTypeWithout(Type, newType);
                }
                else
                {
                    return newType;
                }
            }
            else
            {
                return Type;
            }
        }
    }

    private bool HasMatchNeedsToChange(Field field, ChipColor type, int x, int y)
    {
        //check left
        if (x >= 2)
        {
            if (field.FieldMatrix[x - 1, y].NormalChipType == type && field.FieldMatrix[x - 2, y].NormalChipType == type)
                // so if it is a normal chip? if not -> break. ok
                //But! how can I compare IChip with IChip?
            {
                return true;
            }
        }

        //check top
        if (y >= 2)
        {
            if (field.FieldMatrix[x, y - 1].NormalChipType == type && field.FieldMatrix[x, y - 2].NormalChipType == type)
            {
                return true;
            }
        }

        return false;        
    }


    private ChipColor NewTypeWithout(ChipColor bannedType)
    {
        List<ChipColor> possibleTypes = new List<ChipColor>();

        //foreach (NormalChipType t in (NormalChipType[])Enum.GetValues(typeof(NormalChipType)))
        foreach (ChipColor t in Enum.GetValues(typeof(ChipColor)))
        {
            if (t != bannedType)
            {
                if (t != ChipColor.Total)
                {
                    possibleTypes.Add(t);
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleTypes.Count);
        return possibleTypes[i];
    }

    private ChipColor NewTypeWithout(ChipColor type, ChipColor newType)
    {
        List<ChipColor> possibleTypes = new List<ChipColor>();
        //foreach (NormalChipType t in (NormalChipType[])Enum.GetValues(typeof(NormalChipType)))

        foreach (ChipColor t in Enum.GetValues(typeof(ChipColor)))
        {
            if (t != type)
            {
                if (t != newType)
                {
                    if (t != ChipColor.Total)
                    {
                        possibleTypes.Add(t);
                    }
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleTypes.Count);
        return possibleTypes[i];
    }

    ChipColor GetRandomType()
    {
        return (ChipColor)UnityEngine.Random.Range(0, (int)ChipColor.Total);
    }
}
