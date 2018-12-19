using UnityEngine;

public class ChipWorldPositionProvider : IChipPositionProvider
{
    readonly FieldVisualizationParameters _fieldVisualizationParameters;
    readonly float _worldScreenHeight;
    readonly float _worldScreenWidth;
    readonly float _fieldBound;
    Vector2 _spawningOffset;
    float _itemSize;

    public ChipWorldPositionProvider(   FieldVisualizationParameters visualizationParameters,
                                        Camera camera)
    {
        _fieldVisualizationParameters = visualizationParameters;

        _worldScreenHeight = camera.orthographicSize * 2.0f;
        _worldScreenWidth = _worldScreenHeight / Screen.height * Screen.width;
        //Debug.LogFormat("World Screen Size detected: width = {0}, Height = {1}", _worldScreenWidth, _worldScreenHeight);

        //Calculate Field Bounds. Field always square! even 2x8 or 8x2
        _fieldBound = ((_worldScreenWidth > _worldScreenHeight) ? _worldScreenHeight : _worldScreenWidth) - _fieldVisualizationParameters.ScreenMargin * 2;

    }

    public Vector3 GetPosition(int elementX, int elementY)
    {
        //Offset is unknown yet...
        
        var Position = new Vector3
        {
            x = _spawningOffset.x + elementX * _itemSize,
            y = _spawningOffset.y - elementY * _itemSize,
            z = 1
        };

        return Position;
    }

    /// <summary>
    /// Assumes that 128 pixels = 1 Unit (image import settings)
    /// </summary>
    /// <param name="fieldTotalItemsX"></param>
    /// <param name="fieldTotalItemsY"></param>
    /// <returns></returns>
    public float CalculateChipSize(int fieldTotalItemsX, int fieldTotalItemsY)
    {
        //Find element size, based on bounds 
        _itemSize = (fieldTotalItemsX > fieldTotalItemsY) ? (_fieldBound / fieldTotalItemsX) : (_fieldBound / fieldTotalItemsX);

        //Check for limits
        _itemSize = ChipSizeCheckForLimits();

        //Clalculate offset, so that element [0:0] would be at top level corner
        _spawningOffset = new Vector2(fieldTotalItemsX * _itemSize * (-0.5f) + _itemSize * 0.5f, fieldTotalItemsY * _itemSize * (0.5f) - _itemSize * 0.5f);

        return _itemSize;
    }

    float ChipSizeCheckForLimits()
    {
        return (_itemSize > _fieldVisualizationParameters.MaxChipSizeInUnits) ? _fieldVisualizationParameters.MaxChipSizeInUnits : _itemSize;
    }
}
