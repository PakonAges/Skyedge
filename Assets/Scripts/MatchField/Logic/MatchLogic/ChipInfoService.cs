public class ChipInfoService : IChipInfoService
{
    public bool IsColored(IChip chip, ChipColor color)
    {
        if (chip.ChipType != ChipType.ColorChip)
        {
            return false;
        }
        else if (chip.MyGo.GetComponent<ColorChip>().Color != color)
        {
            return false;
        }
        else return true;
        //return true;
    }

    public bool IsBothColoredAndSameColor(IChip chip1, IChip chip2)
    {
        //if (chip1.ChipType != ChipType.ColorChip || chip2.ChipType != ChipType.ColorChip)
        //{
        //    return false;
        //}
        //else if (chip1.MyGo.GetComponent<ColorChip>().Color != chip2.MyGo.GetComponent<ColorChip>().Color)
        //{
        //        return false;
        //}
        //else return true;
        return true;
    }

    public bool IsSameType(IChip chip1, IChip chip2)
    {
        //if (chip1.ChipType == chip2.ChipType)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return true;
    }

    public T GetTypeData<T>(IChip chip)
    {
        return chip.MyGo.GetComponent<T>();
    }
}
