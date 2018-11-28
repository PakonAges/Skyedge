public class FieldData
{
    public int Xsize { get; private set; }
    public int Ysize { get; private set; }
    public int NumberOfElements { get; private set; }
    public int[,] FieldMatrix;

    public FieldData(int xSize, int ySize, int NumberOfElements)
    {
        Xsize = xSize;
        Ysize = ySize;
        this.NumberOfElements = NumberOfElements;
        FieldMatrix = new int[Xsize, Ysize];
    }
}