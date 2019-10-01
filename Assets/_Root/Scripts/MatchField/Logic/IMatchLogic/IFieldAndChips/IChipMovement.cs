using System.Threading.Tasks;

public interface IChipMovement
{
    Task MoveAsync(IChip chip, int newX, int newY);
    Task<bool> SwapAsync(IChip chip1, IChip chip2);
}
