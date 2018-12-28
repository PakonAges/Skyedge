using System.Threading.Tasks;

public interface IChipMovement
{
    Field GameField { get; set; }
    Task<bool> Move(Chip chip, int newX, int newY);
    Task<bool> Swap(Chip chip1, Chip chip2);
}
