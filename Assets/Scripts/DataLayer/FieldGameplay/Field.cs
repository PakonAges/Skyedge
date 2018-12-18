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
}