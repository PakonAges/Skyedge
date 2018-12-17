public class Chip
{
    public int X { get; }
    public int Y { get; }
    public ChipType ChipType { get; }

    public Chip(int x, int y, ChipType chiptype)
    {
        X = x;
        Y = y;
        ChipType = chiptype;
    }
}