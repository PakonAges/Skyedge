public interface IChipPainter
{
    void PaintEmptyChip(Chip chip);
    void Paint(Chip chip, ChipColor newType);
    void PaintRandomType (Chip chip);
}
