public class Field
{
    public int Xsize { get; private set; }
    public int Ysize { get; private set; }
    public int NumberOfElements { get; private set; }
    public Chip[,] FieldMatrix;

    public Field(int xSize, int ySize, int NumberOfElements)
    {
        Xsize = xSize;
        Ysize = ySize;
        this.NumberOfElements = NumberOfElements;
        FieldMatrix = new Chip[Xsize, Ysize];
    }
}