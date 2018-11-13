public class MatchGrid
{
    public readonly int Xsize = 8;
    public readonly int Ysize = 8;

    public GridElement[,] FieldGrid;

    public MatchGrid()
    {
        FieldGrid = new GridElement[Xsize, Ysize];

        for (int x = 0; x < Xsize; x++)
        {
            for (int y = 0; y < Ysize; y++)
            {
                FieldGrid[x, y] = GridElement.Blue;
            }
        }
    }
}
