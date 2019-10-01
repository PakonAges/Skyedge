using UnityEngine;

public class ChipSizeProvider : IChipSizeProvider
{
    readonly FieldVisualizationParameters _fieldVisualizationParameters;
    readonly float _worldScreenHeight;
    readonly float _worldScreenWidth;
    readonly float _fieldBound;

    public ChipSizeProvider(FieldVisualizationParameters visualizationParameters,
                            Camera camera)
    {
        _fieldVisualizationParameters = visualizationParameters;
        _worldScreenHeight = camera.orthographicSize * 2.0f;
        _worldScreenWidth = _worldScreenHeight / Screen.height * Screen.width;

        //Calculate Field Bounds. Field always square! even 2x8 or 8x2
        _fieldBound = ((_worldScreenWidth > _worldScreenHeight) ? _worldScreenHeight : _worldScreenWidth) - _fieldVisualizationParameters.ScreenMargin * 2;
    }

    // Assumes that 128 pixels = 1 Unit (image import settings)
    public float CalculateChipSize(int FieldSizeX, int FieldSizeY)
    {
        var ChipSize = (FieldSizeX > FieldSizeY) ? (_fieldBound / FieldSizeX) : (_fieldBound / FieldSizeY);
        return ChipSizeCheckForLimits(ChipSize);
    }

    float ChipSizeCheckForLimits(float CalculatedSize)
    {
        return (CalculatedSize > _fieldVisualizationParameters.MaxChipSizeInUnits) ? _fieldVisualizationParameters.MaxChipSizeInUnits : CalculatedSize;
    }
}