using UnityEngine;

public class ChipSpawner : IChipSpawner
{
    readonly Chip.Factory _chipFactory;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipMovement _chipMovement;
    
    public ChipSpawner( Chip.Factory chipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider,
                        IChipMovement chipMovement)
    {
        _chipFactory = chipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
        _chipMovement = chipMovement;
    }

    public Chip SpawnChip(ChipType Chip, int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create(/*Chip*/);
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.ChipType = Chip;

        if (Chip == ChipType.NormalChip)
        {
            newChip.IsMoveable = true;
            _chipMovement.Move(newChip, Xpos, Ypos);
        }

        return newChip;
    }

    public void SetupChip(Sprite Image, float Scale)
    {
        //?
    }
}
