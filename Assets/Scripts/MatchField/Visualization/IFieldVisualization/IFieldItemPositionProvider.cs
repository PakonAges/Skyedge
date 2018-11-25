using UnityEngine;

public interface IFieldItemWorldPositionProvider
{
    Vector3 WorldPosition(int elementX, int elementY, int fieldSizeX, int fieldSizeY);
}