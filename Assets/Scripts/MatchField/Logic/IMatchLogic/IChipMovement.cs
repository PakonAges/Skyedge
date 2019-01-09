using System.Threading.Tasks;

public interface IChipMovement
{
    Field GameField { get; set; }
    Task MoveAsync(IChip chip, int newX, int newY);
    Task<bool> SwapAsync(IChip chip1, IChip chip2);
}
