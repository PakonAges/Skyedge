﻿using System.Threading.Tasks;

public interface IChipManager
{
    Chip SpawnEmptyChip(int Xpos, int Ypos); //So should I return Chip/Empty/Or void?
    Task<Chip> SpawnRandomChip(int Xpos, int Ypos);
    Chip SpawnNormalChip(NormalChipType normalType, int Xpos, int Ypos);
    void RemoveChip(Chip chip);
}