public class FieldGenerator : IFieldGenerator
{
    readonly IChipSpawner _chipSpawner;
    
    public FieldGenerator (IChipSpawner chipSpawner)
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
                NewField.FieldMatrix[x, y] = _chipSpawner.SpawnChip(ChipType.NormalChip, x, y);
            }
        }

        //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);

        return NewField;
    }
}
