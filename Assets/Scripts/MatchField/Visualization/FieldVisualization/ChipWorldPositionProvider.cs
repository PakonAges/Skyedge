using UnityEngine;

public class ChipWorldPositionProvider : IChipPositionProvider
{
    readonly FieldVisualizationParameters _fieldVisualizationParameters;
    readonly int _screenSizeX;
    readonly int _screenSizeY;
    readonly float _worldScreenHeight;
    readonly float _worldScreenWidth;
    Vector2 _spawningOffset;
    float _itemSize;

    public ChipWorldPositionProvider(   FieldVisualizationParameters visualizationParameters,
                                        Camera camera)
    {
        _screenSizeX = Screen.width;
        _screenSizeY = Screen.height;
        _fieldVisualizationParameters = visualizationParameters;
        //Debug.LogFormat("Screen Size detected: X = {0}, Y = {1}", ScreenSizeX, ScreenSizeY);

        _worldScreenHeight = camera.orthographicSize * 2.0f;
        _worldScreenWidth = _worldScreenHeight / Screen.height * Screen.width;
        //Debug.LogFormat("World Screen Size detected: width = {0}, Height = {1}", _worldScreenWidth, _worldScreenHeight);
    }

    public Vector3 GetPosition(int elementX, int elementY)
    {
        var Position = new Vector3
        {
            x = _spawningOffset.x + elementX * _itemSize,
            //x = elementX * itemSize,

            y = _spawningOffset.y - elementY * _itemSize,
            //y = elementY * itemSize,
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
        //Calculate Field Bounds. Field always square! even 2x8 or 8x2
        var FieldBound = ((_worldScreenWidth > _worldScreenHeight) ? _worldScreenHeight : _worldScreenWidth) - _fieldVisualizationParameters.ScreenMargin * 2;

        //Find element size, based on bounds 
        _itemSize = (fieldTotalItemsX > fieldTotalItemsY) ? (FieldBound / fieldTotalItemsX) : (FieldBound / fieldTotalItemsX);

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
