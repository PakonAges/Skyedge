public interface IFieldItemTypeProvider
{
    FieldItemTypes.FieldItemType GetType(FieldData fieldData, int cellX, int cellY);

}
