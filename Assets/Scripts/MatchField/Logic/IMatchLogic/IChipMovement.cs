using System.Threading.Tasks;

public interface IChipMovement
{
    Field GameField { get; set; }
    Task MoveAsync(Chip chip, int newX, int newY);
    Task<bool> SwapAsync(Chip chip1, Chip chip2);
}
