using System.Threading.Tasks;

public interface IFieldFiller
{
    Field GameField { get; set; }
    Task FullFillAsync();
}
