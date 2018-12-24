public interface IChipPainter
{
    void PaintEmptyChip(Chip chip);
    void Paint(Chip chip, NormalChipType newType);
    void PaintRandomType (Chip chip);
}
