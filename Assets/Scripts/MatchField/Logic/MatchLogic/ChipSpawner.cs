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

    public Chip SpawnEmptyChip(int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create();
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(ChipType.EmptyCell, Xpos, Ypos);
        newChip.IsMovable = false;
        newChip.IsColored = false;
        newChip.IsClearable = false;
        _normalChipPainter.PaintEmptyChip(newChip);

        return newChip;
    }

    public Chip SpawnRandomChip(int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create();
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(ChipType.NormalChip, Xpos, Ypos);
        newChip.IsMovable = true;
        newChip.IsColored = true;
        newChip.IsClearable = true;
        _normalChipPainter.PaintRandomType(newChip);

        return newChip;
    }

    public Chip SpawnNormalChip(NormalChipType normalType, int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create();
        newChip.name = "Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(ChipType.NormalChip, Xpos, Ypos);
        newChip.IsMovable = true;
        newChip.IsColored = true;
        newChip.IsClearable = true;
        _normalChipPainter.Paint(newChip, normalType);

        return newChip;
    }
}
