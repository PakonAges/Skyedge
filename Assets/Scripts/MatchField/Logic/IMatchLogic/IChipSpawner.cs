public interface IChipSpawner
{
    Chip SpawnEmptyChip(int Xpos, int Ypos); //So should I return Chip/Empty/Or void?
    Chip SpawnRandomChip(int Xpos, int Ypos);
    Chip SpawnNormalChip(NormalChipType normalType, int Xpos, int Ypos);
}
