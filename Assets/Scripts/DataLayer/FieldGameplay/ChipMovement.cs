using UnityEngine;

public class ChipMovement
{
    private Transform _chipTransform;

    public ChipMovement (Transform chipTransform)
    {
        _chipTransform = chipTransform;
    }

    public void Move(int newX, int newY)
    {
        //Converter Local position -> Board Position
        //Vise Versa

        //Chip local position = new world position
    }
}
