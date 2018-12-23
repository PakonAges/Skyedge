using UnityEngine;

public class ChipSpawner : IChipSpawner
{
    readonly Chip.Factory _chipFactory;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    
    public ChipSpawner( Chip.Factory chipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider)
    {
        _chipFactory = chipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
    }

    public Chip SpawnChip(ChipType Chip, int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create(/*Chip*/);
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.ChipType = Chip;

         return newChip;
    }

    public void SetupChip(Sprite Image, float Scale)
    {
        //?
    }
}
