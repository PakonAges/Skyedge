public class ChipComparer : IChipComparer
{
    public bool IsSameColor(IChip chip1, IChip chip2)
    {
        if (chip1.ChipType != ChipType.NormalChip || chip2.ChipType != ChipType.NormalChip)
        {
            return false;
        }
        else if (chip1.MyGo.GetComponent<ColorChip>().Color != chip2.MyGo.GetComponent<ColorChip>().Color)
        {
                return false;
        }
        else return true;
    }

    public bool IsSameType(IChip chip1, IChip chip2)
    {
        if (chip1.ChipType == chip2.ChipType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
