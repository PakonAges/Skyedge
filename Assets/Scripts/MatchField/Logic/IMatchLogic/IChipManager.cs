public interface IChipManager
{
    Chip SpawnEmptyChip(int Xpos, int Ypos); //So should I return Chip/Empty/Or void?
    Chip SpawnRandomChip(int Xpos, int Ypos);
    Chip SpawnNormalChip(ChipColor normalType, int Xpos, int Ypos);
    //Spawn Hero
    //Spawn Enemy IEnemyProvider/Spawner
    void RemoveChip(Chip chip);
}
