using UnityEngine;

public interface IChipPositionProvider
{
    int FieldSizeX { get; }
    int FieldSizeY { get; }
    float ChipSize { get; }
    Vector3 GetPosition(int elementX, int elementY);
}