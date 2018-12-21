using UnityEngine;

public interface IChipPositionProvider
{
    int FieldSizeX { get; set; }
    int FieldSizeY { get; set; }
    float ChipSize { get; set; }
    Vector2 SpawnOffset { get; set; }
    Vector3 GetPosition(int elementX, int elementY);

    void SetupChipParameters(int FieldSizeX, int FieldSizeY);
}