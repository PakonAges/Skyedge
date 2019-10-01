public interface IChipInfoService
{
    bool IsColored(IChip chip, ChipColor color);
    bool IsSameType(IChip chip1, IChip chip2);
    bool IsBothColoredAndSameColor(IChip chip1, IChip chip2);
    T GetTypeData<T>(IChip chip);
}
