public class FieldItemTypeProvider : IFieldItemTypeProvider
{
    public FieldItemType GetType(FieldData fieldData, int cellX, int cellY)
    {
        var id = fieldData.FieldMatrix[cellX, cellY];
        return (FieldItemType)id;
    }
}
