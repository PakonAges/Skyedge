using System.Threading.Tasks;

public interface IFieldFiller
{
    Field GameField { get; set; }
    MoveDirection FillDirection { get; set; }
    Task FullFillAsync();
}
