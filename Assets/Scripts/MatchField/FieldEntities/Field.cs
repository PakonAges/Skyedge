public class Field
{
    public int Xsize { get; }
    public int Ysize { get; }
    public Chip[,] FieldMatrix;

    public Field(int xSize, int ySize)
    {
        Xsize = xSize;
        Ysize = ySize;
        FieldMatrix = new Chip[Xsize, Ysize];
    }

    public bool IsAdjacement(Chip chip1, Chip chip2)
    {
        return (chip1.X == chip2.X && (int)UnityEngine.Mathf.Abs(chip1.Y - chip2.Y) == 1) ||
                (chip1.Y == chip2.Y && (int)UnityEngine.Mathf.Abs(chip1.X - chip2.X) == 1);
    }
}