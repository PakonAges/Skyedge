using UnityEngine;

public class FieldItemWorldPositionProvider : IFieldItemWorldPositionProvider
{
    public Vector3 WorldPosition(int elementX, int elementY, int fieldSizeX, int fieldSizeY)
    {
        var Position = new Vector3
        {
            x = elementX,
            y = elementY
        };

        //Calculate size and Position based on SreenSize and Number of Elements

        return Position;
    }
}
