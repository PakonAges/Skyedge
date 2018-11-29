using UnityEngine;

public class FieldItemWorldPositionProvider : IFieldItemWorldPositionProvider
{
    public FieldVisualizationParameters VisualParameters { get; private set; }

    public int ScreenSizeX { get; private set; }
    public int ScreenSizeY { get; private set; }
    public Vector2 SpawningOffset { get; private set; }
    private float itemSize;

    public FieldItemWorldPositionProvider(FieldVisualizationParameters visualizationParameters)
    {
        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
        VisualParameters = visualizationParameters;
        Debug.LogFormat("Screen Size detected: X = {0}, Y = {1}", ScreenSizeX, ScreenSizeY);
    }

    public Vector3 WorldPosition(int elementX, int elementY)
    {
        var Position = new Vector3
        {
            x = SpawningOffset.x + elementX * itemSize,
            y = SpawningOffset.y + elementY * itemSize
        };

        return Position;
    }

    //Size in pixels! But What I really need is a screen Size! because... well nah. Max size is not valid for Retina display and so on. My Field should be limited by... percentage?
    public float CalculateItemSize(int fieldTotalItemsX, int fieldTotalItemsY)
    {
        float PossibleFieldSizeX = ScreenSizeX - 2 * VisualParameters.ScreenMargin;
        float PossibleFieldSizeY = ScreenSizeY - 2 * VisualParameters.ScreenMargin;

        float PossibleElementSizeX = PossibleFieldSizeX / fieldTotalItemsX;
        float PossibleElementSizeY = PossibleFieldSizeY / fieldTotalItemsY;

        float minPossibleEmenetSize = (PossibleFieldSizeX > PossibleFieldSizeY) ? PossibleFieldSizeY : PossibleFieldSizeX;
        float Result = (minPossibleEmenetSize > VisualParameters.MaxItemSize) ? VisualParameters.MaxItemSize : minPossibleEmenetSize;

        SpawningOffset = CalculateOffset(Result, fieldTotalItemsX, fieldTotalItemsY);
        itemSize = Result;

        return Result;
    }

    Vector2 CalculateOffset(float itemSize, int fieldTotalItemsX, int fieldTotalItemsY)
    {
        Vector2 offset = new Vector2();
        offset.x = (-0.5f) * itemSize * fieldTotalItemsX;
        offset.y = (-0.5f) * itemSize * fieldTotalItemsY;
        return offset;
    }
}
