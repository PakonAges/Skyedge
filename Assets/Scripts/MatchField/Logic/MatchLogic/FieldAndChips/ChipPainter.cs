using UnityEngine;

public class ChipPainter : IChipPainter
{
    readonly IChipVisualProvider _chipVisualProvider;

    public ChipPainter(IChipVisualProvider chipVisualProvider)
    {
        _chipVisualProvider = chipVisualProvider;
    }

    public void Paint(ColorChip chip, ChipColor color)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = _chipVisualProvider.GetChipSprite(color);
        chip.Color = color;
        sr.enabled = true;
    }

    //public void PaintEmptyChip(Chip chip)
    //{
    //    var sr = chip.GetComponentInChildren<SpriteRenderer>();
    //    sr.enabled = false;
    //}

    public void PaintRandomColor(ColorChip chip)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        var newColor = (ChipColor)Random.Range(0, (int)ChipColor.Total);
        sr.sprite = _chipVisualProvider.GetChipSprite(newColor);
        chip.Color = newColor;
        sr.enabled = true;
    }
}
