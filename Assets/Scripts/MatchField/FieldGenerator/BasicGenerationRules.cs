public class BasicGenerationRules : IFieldGenerationRules
{
    public BasicGenerationRules(int Xsize, int Ysize, int ElementsAmount)
    {
        this.Xsize = Xsize;
        this.Ysize = Ysize;
        this.NumberOfBasicElements = ElementsAmount;
    }

    public int Xsize { get; set; }
    public int Ysize { get; set; }
    public int NumberOfBasicElements { get; set; }
}
