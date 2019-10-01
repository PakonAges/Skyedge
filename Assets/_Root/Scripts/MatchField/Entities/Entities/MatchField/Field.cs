public class Field
{
    public int Xsize { get; }
    public int Ysize { get; }
    public IChip[,] FieldMatrix;

    public Field(int xSize, int ySize)
    {
        Xsize = xSize;
        Ysize = ySize;
        FieldMatrix = new IChip[Xsize, Ysize];
    }

    public bool IsAdjacement(IChip chip1, IChip chip2)
    {
        return (chip1.X == chip2.X && (int)UnityEngine.Mathf.Abs(chip1.Y - chip2.Y) == 1) ||
                (chip1.Y == chip2.Y && (int)UnityEngine.Mathf.Abs(chip1.X - chip2.X) == 1);
    }
}