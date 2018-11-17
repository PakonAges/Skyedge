public class BasicField : IField
{
    public int[,] Field;

    public BasicField (int Xsize, int Ysize)
    {
        Field = new int[Xsize, Ysize];
    }
}
