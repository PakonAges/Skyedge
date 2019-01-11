using UnityEngine;

public class ChipVisualProvider : IChipVisualProvider
{
    private ColorChipCollection _fieldItemCollection;

    public ChipVisualProvider(ColorChipCollection fieldItemCollection)
    {
        _fieldItemCollection = fieldItemCollection;
    }

    public Sprite GetChipSprite(ChipColor type)
    {
        return _fieldItemCollection.GetChipImage(type);
    }
}
