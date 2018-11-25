public class FieldData : IFieldData {

    public int Xsize { get; set; }
    public int Ysize { get; set; }
    public int NumberOfElements { get; set; }
    public int[,] FieldMatrix;

    public FieldData(int xSize, int ySize, int NumberOfElements)
    {
        Xsize = xSize;
        Ysize = Ysize;
        this.NumberOfElements = NumberOfElements;
        FieldMatrix = new int[Xsize, Ysize];
    }
}
