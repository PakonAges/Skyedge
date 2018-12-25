using System.Threading.Tasks;

public interface IChipMovement
{
    Task Move(Chip chip, int newX, int newY);
}
