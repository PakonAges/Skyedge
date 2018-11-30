using UnityEngine;

public interface IFieldVisualization
{
    void ShowBackGround(Sprite image);
    void ShowField(FieldData fieldData);
    void ResetField(FieldData fieldData);
}
