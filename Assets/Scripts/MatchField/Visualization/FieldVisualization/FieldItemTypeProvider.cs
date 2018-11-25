public class FieldItemTypeProvider : IFieldItemTypeProvider
{
    public FieldItemTypes.FieldItemType GetType(FieldData fieldData, int cellX, int cellY)
    {
        var id = fieldData.FieldMatrix[cellX, cellY];
        FieldItemTypes.FieldItemType type = FieldItemTypes.FieldItemType(id);
        return type;
    }
}
