public class ChipTypeProvider : IChipTypeProvider
{
    public ChipType GetType(Field fieldData, int cellX, int cellY)
    {
        var chip = fieldData.FieldMatrix[cellX, cellY];
        return chip.ChipType;
    }
}
