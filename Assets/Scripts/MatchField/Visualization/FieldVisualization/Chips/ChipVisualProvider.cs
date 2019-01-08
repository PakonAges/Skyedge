using UnityEngine;

public class ChipVisualProvider : IChipVisualProvider
{
    private NormalChipCollection _fieldItemCollection;

    public ChipVisualProvider(NormalChipCollection fieldItemCollection)
    {
        _fieldItemCollection = fieldItemCollection;
    }

    public Sprite GetChipSprite(ChipColor type)
    {
        return _fieldItemCollection.GetChipImage(type);
    }
}
