public interface IChipManager
{
    IChip SpawnEmptyChip(int Xpos, int Ypos); //So should I return Chip/Empty/Or void?
    IChip SpawnRandomChip(int Xpos, int Ypos);
    IChip SpawnColorChip(ChipColor normalType, int Xpos, int Ypos);
    //Spawn Hero
    //Spawn Enemy IEnemyProvider/Spawner
    void RemoveChip(IChip chip);
}
