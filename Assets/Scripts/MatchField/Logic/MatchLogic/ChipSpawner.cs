public class ChipSpawner : IChipSpawner
{
    readonly Chip.Factory _chipFactory;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipMovement _chipMovement;
    readonly IChipPainter _normalChipPainter;

    public ChipSpawner( Chip.Factory chipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider,
                        IChipMovement chipMovement,
                        IChipPainter normalChipPainter)
    {
        _chipFactory = chipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
        _chipMovement = chipMovement;
        _normalChipPainter = normalChipPainter;
    }

    public Chip SpawnChip(ChipType Chip, int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create(/*Chip*/);
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(Chip, Xpos, Ypos);

        if (Chip == ChipType.EmptyCell)
        {
            newChip.IsMovable = false;
            newChip.IsColored = false;
            _normalChipPainter.PaintEmptyChip(newChip);
            return newChip;
        }

        if (Chip == ChipType.NormalChip)
        {
            newChip.IsMovable = true;
            newChip.IsColored = true;
            //_chipMovement.Move(newChip, Xpos, Ypos);
            _normalChipPainter.PaintRandomType(newChip);
            return newChip;
        }

        return newChip;
    }
}
