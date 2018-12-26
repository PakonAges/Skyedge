using System.Threading.Tasks;

public interface IChipMovement
{
    Task<bool> Move(Chip chip, int newX, int newY);
}
