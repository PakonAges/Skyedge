using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChipManager : IChipManager
{
    readonly float _spawnDuraion;
    readonly Chip.Factory _chipFactory;
    readonly List<Chip> _chips = new List<Chip>();
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipMovement _chipMovement;
    readonly IChipPainter _normalChipPainter;

    public ChipManager( Chip.Factory chipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider,
                        IChipMovement chipMovement,
                        IChipPainter normalChipPainter,
                        FieldVisualizationParameters fieldVisualizationParameters)
    {
        _chipFactory = chipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
        _chipMovement = chipMovement;
        _normalChipPainter = normalChipPainter;
        _spawnDuraion = fieldVisualizationParameters.SpawnDuration;
    }

    public Chip SpawnEmptyChip(int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create();
        newChip.name = "Empty Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(ChipType.EmptyCell, Xpos, Ypos);
        newChip.IsMovable = false;
        newChip.IsColored = false;
        newChip.IsClearable = false;
        _normalChipPainter.PaintEmptyChip(newChip);
        _chips.Add(newChip);

        return newChip;
    }

    public async Task<Chip> SpawnRandomChipAsync(int Xpos, int Ypos)
    {
        try
        {
            var newChip = _chipFactory.Create();
            newChip.name = "Rand Chip [" + Xpos + ";" + Ypos + "]";
            newChip.Scale = _chipPositioner.ChipSize;
            newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
            newChip.InitChip(ChipType.NormalChip, Xpos, Ypos);
            newChip.IsMovable = true;
            newChip.IsColored = true;
            newChip.IsClearable = true;
            _normalChipPainter.PaintRandomType(newChip);
            _chips.Add(newChip);
            //await new WaitForSeconds(_spawnDuraion);
            await new WaitForFixedUpdate();
            return newChip;
        }
        catch
        {
            Debug.LogErrorFormat("Trying to spawn Random Chip at [{0}:{1}]", Xpos, Ypos);
        }
        return null;
    }

    public Chip SpawnNormalChip(NormalChipType normalType, int Xpos, int Ypos)
    {
        var newChip = _chipFactory.Create();
        newChip.name = "N Chip [" + Xpos + ";" + Ypos + "]";
        newChip.Scale = _chipPositioner.ChipSize;
        newChip.Position = _chipPositioner.GetPosition(Xpos, Ypos);
        newChip.InitChip(ChipType.NormalChip, Xpos, Ypos);
        newChip.IsMovable = true;
        newChip.IsColored = true;
        newChip.IsClearable = true;
        _normalChipPainter.Paint(newChip, normalType);
        _chips.Add(newChip);

        return newChip;
    }

    public void RemoveChip(Chip chip)
    {
        chip.Dispose();
        _chips.Remove(chip);
    }
}
