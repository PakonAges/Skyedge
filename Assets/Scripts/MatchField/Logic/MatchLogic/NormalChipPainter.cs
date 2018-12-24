using UnityEngine;

public class NormalChipPainter : INormalChipPainter
{
    readonly IChipVisualProvider _chipVisualProvider;

    public NormalChipPainter(IChipVisualProvider chipVisualProvider)
    {
        _chipVisualProvider = chipVisualProvider;
    }

    public void Paint(Chip chip, NormalChipType newType)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = _chipVisualProvider.GetChipSprite(newType);
        chip.NormalChipType = newType;
    }

    public void PaintRandomType(Chip chip)
    {
        var sr = chip.GetComponentInChildren<SpriteRenderer>();
        var newType = (NormalChipType)Random.Range(0, (int)NormalChipType.Total);
        sr.sprite = _chipVisualProvider.GetChipSprite(newType);
        chip.NormalChipType = newType;
    }
}
