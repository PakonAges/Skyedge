using UnityEngine;

public interface IChipPositionProvider
{
    Vector3 GetPosition(int elementX, int elementY);
    float CalculateChipSize(int FieldItemsAmountX, int FieldItemsAmountY);
}