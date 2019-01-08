using UnityEngine;

public class ChipPainter : IChipPainter
{
    readonly IChipVisualProvider _chipVisualProvider;

    public ChipPainter(IChipVisualProvider chipVisualProvider)
    {
        _chipVisualProvider = chipVisualProvider;
    }

    public void Paint(Chip chip, ChipColor newType)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = _chipVisualProvider.GetChipSprite(newType);
        chip.NormalChipType = newType;
        sr.enabled = true;
    }

    public void PaintEmptyChip(Chip chip)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        sr.enabled = false;
    }

    public void PaintRandomType(Chip chip)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        var newType = (ChipColor)Random.Range(0, (int)ChipColor.Total);
        sr.sprite = _chipVisualProvider.GetChipSprite(newType);
        chip.NormalChipType = newType;
        sr.enabled = true;
    }
}
