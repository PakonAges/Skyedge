using System.Threading.Tasks;

public interface IFieldFiller
{
    Field GameField { get; set; }
    FieldFillDirection FillDirection { get; set; }
    Task FullFillAsync();
}
