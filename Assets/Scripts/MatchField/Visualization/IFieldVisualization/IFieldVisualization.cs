using UnityEngine;

public interface IFieldVisualization
{
    void ShowEmptyGrid(int Xsize, int Ysize);
    void ShowField(Field field);
    void ResetField(Field field);
}
