using UnityEngine;

public class ChipWorldPositionProvider : IChipPositionProvider
{
    public FieldVisualizationParameters VisualParameters { get; private set; }

    public int ScreenSizeX { get; private set; }
    public int ScreenSizeY { get; private set; }
    public Vector2 SpawningOffset { get; private set; }
    private float itemSize;

    public ChipWorldPositionProvider(FieldVisualizationParameters visualizationParameters)
    {
        ScreenSizeX = Screen.width;
        ScreenSizeY = Screen.height;
        VisualParameters = visualizationParameters;
        Debug.LogFormat("Screen Size detected: X = {0}, Y = {1}", ScreenSizeX, ScreenSizeY);
    }

    public Vector3 GetPosition(int elementX, int elementY)
    {
        var Position = new Vector3
        {
            x = SpawningOffset.x + elementX * itemSize,
            //x = elementX * itemSize,

            y = SpawningOffset.y + elementY * itemSize,
            //y = elementY * itemSize,
            z = 1
        };

        return Position;
    }


    public float CalculateItemSize(Camera came, int fieldTotalItemsX, int fieldTotalItemsY)
    {
        var worldScreenHeight = came.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        //Calculate Field Bounds. Field always square! even 2x8 or 8x2
        //Screen is always vertical. At least in this implementation
        var FieldBound = (float)worldScreenWidth - VisualParameters.ScreenMargin * 2;

        //Find element size, based on bounds 
        itemSize = (fieldTotalItemsX > fieldTotalItemsY) ? (FieldBound / fieldTotalItemsX) : (FieldBound / fieldTotalItemsX);

        //Clalculate offset
        SpawningOffset = new Vector2(FieldBound * (-0.5f) + itemSize * 0.5f, FieldBound * (-0.5f) + itemSize * 0.5f);

        return itemSize;

        //TODO : check for limits! 
        //Offest would be different
    }

    //Vector2 CalculateOffset(float itemSize, int fieldTotalItemsX, int fieldTotalItemsY)
    //{
    //    Vector2 offset = new Vector2();
    //    offset.x = (-0.5f) * itemSize * fieldTotalItemsX;
    //    offset.y = (-0.5f) * itemSize * fieldTotalItemsY;
    //    return offset;
    //}
}
