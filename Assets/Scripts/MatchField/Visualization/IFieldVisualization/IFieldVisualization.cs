using UnityEngine;

public interface IFieldVisualization
{
    void ShowBackGround(Sprite image);
    void ShowField(Field fieldData);
    void ResetField(Field fieldData);
}
