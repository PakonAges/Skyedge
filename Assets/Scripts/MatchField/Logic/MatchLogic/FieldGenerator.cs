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
                NewField.FieldMatrix[x, y] = _chipSpawner.SpawnChip(ChipType.EmptyCell, x, y); //pass reference to MyField?
            }
        }

        //Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator", rules.Xsize, rules.Ysize, rules.ChipTypes.Count);

        return NewField;
    }

    //Create Chip at the place
    //If this is a Normal Piece - add component Moveable? Or is it easier to make it monobehavior?
}
