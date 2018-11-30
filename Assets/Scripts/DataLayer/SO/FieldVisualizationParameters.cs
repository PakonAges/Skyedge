using UnityEngine;

[CreateAssetMenu(menuName = "Data/Field/Field Visualization Parameters")]
public class FieldVisualizationParameters : ScriptableObject
{
    public float ScreenMargin = 0.1f;
    public int MaxItemSize = 100;
    public Sprite DefaultFieldBG;
}
