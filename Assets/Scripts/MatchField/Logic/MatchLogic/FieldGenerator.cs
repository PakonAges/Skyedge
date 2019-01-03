using System;
using System.Collections.Generic;

public class FieldGenerator : IFieldGenerator
{
    readonly IChipManager _chipSpawner;
    
    public FieldGenerator (IChipManager chipSpawner)
    {
        _chipSpawner = chipSpawner;
    }

    public Field GenerateField(FieldGenerationRules rules)
    {
        var NewField = new Field(rules.Xsize, rules.Ysize);

        for (int x = 0; x < rules.Xsize; x++)
        {
            for (int y = 0; y < rules.Ysize; y++)
            {
                NormalChipType type = GetTypeWithoutMatches(NewField, x, y);
                NewField.FieldMatrix[x, y] = _chipSpawner.SpawnNormalChip(type, x, y);
            }
        }

        //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);

        return NewField;
    }

    NormalChipType GetTypeWithoutMatches(Field field, int x, int y)
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

    private bool HasMatchNeedsToChange(Field field, NormalChipType type, int x, int y)
    {
        //check left
        if (x >= 2)
        {
            if (field.FieldMatrix[x - 1, y].NormalChipType == type && field.FieldMatrix[x - 2, y].NormalChipType == type)
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


    private NormalChipType NewTypeWithout(NormalChipType bannedType)
    {
        List<NormalChipType> possibleTypes = new List<NormalChipType>();

        //foreach (NormalChipType t in (NormalChipType[])Enum.GetValues(typeof(NormalChipType)))
        foreach (NormalChipType t in Enum.GetValues(typeof(NormalChipType)))
        {
            if (t != bannedType)
            {
                if (t != NormalChipType.Total)
                {
                    possibleTypes.Add(t);
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleTypes.Count);
        return possibleTypes[i];
    }

    private NormalChipType NewTypeWithout(NormalChipType type, NormalChipType newType)
    {
        List<NormalChipType> possibleTypes = new List<NormalChipType>();
        //foreach (NormalChipType t in (NormalChipType[])Enum.GetValues(typeof(NormalChipType)))

        foreach (NormalChipType t in Enum.GetValues(typeof(NormalChipType)))
        {
            if (t != type)
            {
                if (t != newType)
                {
                    if (t != NormalChipType.Total)
                    {
                        possibleTypes.Add(t);
                    }
                }
            }
        }

        int i = UnityEngine.Random.Range(0, possibleTypes.Count);
        return possibleTypes[i];
    }

    NormalChipType GetRandomType()
    {
        return (NormalChipType)UnityEngine.Random.Range(0, (int)NormalChipType.Total);
    }
}
