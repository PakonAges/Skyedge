using DG.Tweening;

public class ChipMovement : IChipMovement
{
    readonly IChipPositionProvider _chipPositionProvider;

    public ChipMovement (   IChipPositionProvider chipPositionProvider)
    {
        _chipPositionProvider = chipPositionProvider;
    }

    public void Move(Chip chip, int newX, int newY)
    {
        chip.X = newX;
        chip.Y = newY;
        chip.Position = _chipPositionProvider.GetPosition(newX, newY);
        //chip.gameObject.transform.DOMove(_chipPositionProvider.GetPosition(newX, newY),1);
    }
}