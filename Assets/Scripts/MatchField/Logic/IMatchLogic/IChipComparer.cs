public interface IChipComparer
{
    bool IsSameType(IChip chip1, IChip chip2);
    bool IsSameColor(IChip chip1, IChip chip2);
}
