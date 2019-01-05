using System.Threading.Tasks;

public interface IChipManager
{
    Chip SpawnEmptyChip(int Xpos, int Ypos); //So should I return Chip/Empty/Or void?
    Task<Chip> SpawnRandomChipAsync(int Xpos, int Ypos);
    Chip SpawnNormalChip(NormalChipType normalType, int Xpos, int Ypos);
    //Spawn Hero
    //Spawn Enemy IEnemyProvider/Spawner
    void RemoveChip(Chip chip);
}
