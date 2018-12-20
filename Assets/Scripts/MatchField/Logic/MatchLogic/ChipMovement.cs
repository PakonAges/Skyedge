using UnityEngine;

public class ChipMovement : IChipMovement
{
    //private Transform _chipTransform;
    private IChipPositionProvider _chipPositionProvider;

    public ChipMovement (   //Transform chipTransform,
                            IChipPositionProvider chipPositionProvider
                            )
    {
        //_chipTransform = chipTransform;
        _chipPositionProvider = chipPositionProvider;
    }

    //public void Move(Chip Chip, Vector3 Position)
    //{
    //    Chip.ChipTransform.localPosition = Position;
    //}

    public void Move(Chip Chip, int newX, int newY)
    {
        Chip.ChipTransform.localPosition = _chipPositionProvider.GetPosition(newX, newY);
    }
}