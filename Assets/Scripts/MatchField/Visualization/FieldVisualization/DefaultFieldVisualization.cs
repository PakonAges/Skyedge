using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IFieldItemWorldPositionProvider _itemPositioner;
    readonly IFieldItemVisualProvider _fieldItemVisualProvider;
    readonly IFieldItemSpawner _fieldItemSpawner;

    public DefaultFieldVisualization(   IFieldItemWorldPositionProvider fieldItemWorldPositionProvider,
                                        IFieldItemVisualProvider fieldItemVisualProvider,
                                        IFieldItemSpawner fieldItemSpawner)
    {
        _itemPositioner = fieldItemWorldPositionProvider;
        _fieldItemVisualProvider = fieldItemVisualProvider;
        _fieldItemSpawner = fieldItemSpawner;
    }

    public void ShowField(FieldData fieldData)
    {
        float ItemSize = _itemPositioner.CalculateItemSize(fieldData.Xsize, fieldData.Ysize);

        for (int i = 0; i < fieldData.Ysize; i++)
        {
            for (int j = 0; j < fieldData.Xsize; j++)
            {
                var pos = _itemPositioner.WorldPosition(i, j);
                var img = _fieldItemVisualProvider.GetItemSprite((FieldItemType)fieldData.FieldMatrix[i,j]);
                _fieldItemSpawner.CreateItem(img, pos);
            }
        }

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(FieldData fieldData)
    {
        //Way to reset? clear all!
        Debug.Log("Field Resetted from field visualization");
    }
}
