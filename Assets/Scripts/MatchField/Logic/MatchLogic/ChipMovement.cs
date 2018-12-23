public class ChipMovement : IChipMovement
{
    readonly Chip _chip;
    readonly IChipPositionProvider _chipPositionProvider;

    public ChipMovement (   Chip chip,
                            IChipPositionProvider chipPositionProvider)
    {
        _chip = chip;
        _chipPositionProvider = chipPositionProvider;
    }

    public void Move(int newX, int newY)
    {
        _chip.X = newX;
        _chip.Y = newY;
        _chip.Position = _chipPositionProvider.GetPosition(newX, newY);
    }
}