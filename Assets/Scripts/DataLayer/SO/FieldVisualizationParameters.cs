using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Field Visualization Parameters")]
public class FieldVisualizationParameters : ScriptableObject
{
    [Header("Prefab refferences")]
    public GameObject Background;
    public GameObject GridCell;

    [Header("Sprite refferences")]
    public Sprite DefaultFieldBG;
    public Sprite LightCellBg;
    public Sprite DarkCellBg;

    [Header("Size setup")]
    public float ScreenMargin = 0.1f;
    public float MaxChipSizeInUnits = 1;

    [Header("Movement setup")]
    public float MovementDuration = 0.5f;
}