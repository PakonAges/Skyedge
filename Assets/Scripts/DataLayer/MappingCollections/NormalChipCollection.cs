using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Normal Chip Sprites Collection")]
public class NormalChipCollection : ScriptableObject
{
    [Header("Null Sprite")]
    public Sprite NullSprite;

    [Header("Normal Chips Mapping")]
    public NormalChipVisual[] NormalChipVisual;

    public Sprite GetChipImage(NormalChipType type)
    {
        for (int i = 0; i < NormalChipVisual.Length; i++)
        {
            if (NormalChipVisual[i].Type == type)
            {
                return NormalChipVisual[i].Image;
            }
        }

        Debug.LogErrorFormat("Can't find Sprite in collection for this Normal Chip type: {0}", type);
        return NullSprite;
    }
}

[System.Serializable]
public struct NormalChipVisual
{
    public NormalChipType Type;
    public Sprite Image;
}