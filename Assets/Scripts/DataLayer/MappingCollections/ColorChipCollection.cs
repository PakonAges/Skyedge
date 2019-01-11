using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Color Chips Sprites Collection")]
public class ColorChipCollection : ScriptableObject
{
    [Header("Null Sprite")]
    public Sprite NullSprite;

    [Header("Color Chips Mapping")]
    public ColorChipVisual[] ColorChipVisual;

    public Sprite GetChipImage(ChipColor type)
    {
        for (int i = 0; i < ColorChipVisual.Length; i++)
        {
            if (ColorChipVisual[i].Type == type)
            {
                return ColorChipVisual[i].Image;
            }
        }

        Debug.LogErrorFormat("Can't find Sprite in collection for this Color Chip: {0}", type);
        return NullSprite;
    }
}

[System.Serializable]
public struct ColorChipVisual
{
    public ChipColor Type;
    public Sprite Image;
}