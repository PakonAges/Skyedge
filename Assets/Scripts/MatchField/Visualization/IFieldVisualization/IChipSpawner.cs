using UnityEngine;

public interface IChipSpawner
{
    GameObject SpawnChip(ChipType Chip, int Xpos, int Ypos);
    void SetupChip(Sprite Image, float Scale);
}
