using UnityEngine;

public interface IChipSpawner
{
    Chip SpawnChip(ChipType Chip, int Xpos, int Ypos);
    void SetupChip(Sprite Image, float Scale);
}
