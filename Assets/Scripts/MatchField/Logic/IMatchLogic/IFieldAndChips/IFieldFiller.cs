using System.Threading.Tasks;

public interface IFieldFiller
{
    MoveDirection FillDirection { get; set; }
    Task FullFillAsync();
}
