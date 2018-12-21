public interface IFieldVisualization
{
    void SetupVisualization(int FieldSizeX, int FieldSizeY);
    void ShowEmptyGrid(int FieldSizeX, int FieldSizeY);
    void ShowField(Field field);
    void ResetField(Field field);
}
