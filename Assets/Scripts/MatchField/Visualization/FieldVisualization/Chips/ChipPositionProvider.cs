using UnityEngine;
using Zenject;

public class ChipPositionProvider : IChipPositionProvider, IInitializable
{
    readonly IChipSizeProvider _chipSizeProvider;

    //TODO: Add some default ot try/catch to props. cos can be zeros
    public float ChipSize { get; private set; }
    public int FieldSizeX { get; private set; }
    public int FieldSizeY { get; private set; }
    Vector2 SpawnOffset = new Vector2();

    public ChipPositionProvider( IChipSizeProvider chipSizeProvider,
                                 IFieldGenerationRulesProvider fieldGenerationRulesProvider)
    {
        _chipSizeProvider = chipSizeProvider;
        FieldSizeX = fieldGenerationRulesProvider.GetGenerationRules().Xsize;
        FieldSizeY = fieldGenerationRulesProvider.GetGenerationRules().Ysize;
    }

    public void Initialize()
    {
        SetupChipParameters();
    }

    void SetupChipParameters()
    {
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
