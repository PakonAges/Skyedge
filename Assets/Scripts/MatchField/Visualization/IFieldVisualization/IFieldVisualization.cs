using UnityEngine;

public interface IFieldVisualization
{
    void ShowBackGround(Sprite image);
    void ShowEmptyGrid(int Xsize, int Ysize);
    void ShowField(Field field);
    void ResetField(Field field);
}
