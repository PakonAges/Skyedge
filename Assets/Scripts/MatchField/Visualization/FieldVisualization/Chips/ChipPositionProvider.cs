using UnityEngine;

public class ChipPositionProvider : IChipPositionProvider
{
    readonly IChipSizeProvider _chipSizeProvider;

    public float ChipSize { get; set; }
    public Vector2 SpawnOffset { get; set; }
    public int FieldSizeX { get; set; }
    public int FieldSizeY { get; set; }

    public ChipPositionProvider( IChipSizeProvider chipSizeProvider)
    {
        _chipSizeProvider = chipSizeProvider;
    }

    public void SetupChipParameters(int FieldSizeX, int FieldSizeY)
    {
        this.FieldSizeX = FieldSizeX;
        this.FieldSizeY = FieldSizeY;
        ChipSize = _chipSizeProvider.CalculateChipSize(FieldSizeX, FieldSizeY);
        SpawnOffset = CalculateSpawnOffset();
    }

    public Vector3 GetPosition(int elementX, int elementY)
    {
        var Position = new Vector3
        {
            x = SpawnOffset.x + elementX * ChipSize,
            y = SpawnOffset.y - elementY * ChipSize,
            z = 1
        };

        return Position;
    }

    //Clalculate offset, so that element [0:0] would be at top level corner
    Vector2 CalculateSpawnOffset()
    {
        return new Vector2(FieldSizeX * ChipSize * (-0.5f) + ChipSize * 0.5f, FieldSizeY * ChipSize * (0.5f) - ChipSize * 0.5f);
    }
}
