using System;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : IChipManager
{
    readonly float _spawnDuraion;
    readonly ColorChip.Factory _colorChipFactory;
    readonly EmptyChip.Factory _emptyChipFactory;
    readonly List<ColorChip> _colorChips = new List<ColorChip>();
    readonly List<EmptyChip> _emptyChips = new List<EmptyChip>();
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipMovement _chipMovement;
    readonly IChipPainter _normalChipPainter;

    public ChipManager( ColorChip.Factory colorChipFactory,
                        EmptyChip.Factory emptyChipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider,
                        IChipMovement chipMovement,
                        IChipPainter normalChipPainter,
                        FieldVisualizationParameters fieldVisualizationParameters)
    {
        _colorChipFactory = colorChipFactory;
        _emptyChipFactory = emptyChipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
        _chipMovement = chipMovement;
        _normalChipPainter = normalChipPainter;
        _spawnDuraion = fieldVisualizationParameters.SpawnDuration;
    }
    
    public IChip SpawnEmptyChip(int Xpos, int Ypos)
    {
        try
        {
            var newChip = _emptyChipFactory.Create();
            newChip.name = "Empty Chip [" + Xpos + ";" + Ypos + "]";
            newChip.InitChip(Xpos, Ypos, _chipPositioner.ChipSize, _chipPositioner.GetPosition(Xpos, Ypos));
            newChip.IsMovable = false;
            newChip.IsClearable = false;
            _emptyChips.Add(newChip);
            return newChip;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to spawn Empty Chip at [{0}:{1}]", Xpos, Ypos);
        }
        return null;
    }

    public IChip SpawnRandomChip(int Xpos, int Ypos)
    {
        try
        {
            var newChip = _colorChipFactory.Create();
            newChip.name = "Rand Chip [" + Xpos + ";" + Ypos + "]";
            newChip.InitChip(Xpos, Ypos, _chipPositioner.ChipSize, _chipPositioner.GetPosition(Xpos, Ypos));
            newChip.IsMovable = true;
            newChip.IsClearable = true;
            _normalChipPainter.PaintRandomColor(newChip);
            _colorChips.Add(newChip);
            return newChip;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to spawn Random Chip at [{0}:{1}]", Xpos, Ypos);
        }
        return null;
    }

    public IChip SpawnColorChip(ChipColor color, int Xpos, int Ypos)
    {
        try
        {
            var newChip = _colorChipFactory.Create();
            newChip.name = "Rand Chip [" + Xpos + ";" + Ypos + "]";
            newChip.InitChip(Xpos, Ypos, _chipPositioner.ChipSize, _chipPositioner.GetPosition(Xpos, Ypos));
            newChip.IsMovable = true;
            newChip.IsClearable = true;
            _normalChipPainter.Paint(newChip, color);
            _colorChips.Add(newChip);
            return newChip;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to spawn Normal Chip at [{0}:{1}]", Xpos, Ypos);
        }
        return null;
    }

    public void RemoveChip(IChip chip)
    {
        chip.Dispose();

        if (chip.ChipType == ChipType.EmptyChip)
        {
            _emptyChips.Remove(chip.MyGo.GetComponent<EmptyChip>());
        } else if (chip.ChipType == ChipType.ColorChip)
        {
            _colorChips.Remove(chip.MyGo.GetComponent<ColorChip>());
        }
    }
}
