public interface IFieldVisualization
{
    void SetupVisualization(int FieldSizeX, int FieldSizeY);
    void ShowEmptyGrid(int Xsize, int Ysize);
    void ShowField(Field field);
    void ResetField(Field field);
}
