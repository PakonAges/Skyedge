using UnityEngine;

public interface IFieldItemWorldPositionProvider
{
    Vector3 WorldPosition(int elementX, int elementY);
    float CalculateItemSize(int FieldItemsAmountX, int FieldItemsAmountY);
}