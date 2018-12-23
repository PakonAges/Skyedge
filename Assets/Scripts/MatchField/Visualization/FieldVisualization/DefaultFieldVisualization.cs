using UnityEngine;

/// <summary>
/// Visualizes Field based on it's Data
/// </summary>
public class DefaultFieldVisualization : IFieldVisualization
{
    readonly IFieldGridGenerator _fieldGridGenerator;
    readonly IChipPositionProvider _chipPositioner;
    readonly IChipSpriteChanger _chipSpriteChanger;
    readonly IChipVisualProvider _chipVisualProvider;
    readonly IChipSpawner _chipSpawner;
    readonly IChipMovement _chipMovement;

    public DefaultFieldVisualization(   IFieldGridGenerator fieldGridGenerator,
                                        IChipPositionProvider fieldItemWorldPositionProvider,
                                        IChipSpriteChanger chipSpriteChanger,
                                        IChipVisualProvider fieldItemVisualProvider,
                                        IChipSpawner fieldItemSpawner,
                                        IChipMovement chipMovement)
    {
        _fieldGridGenerator = fieldGridGenerator;
        _chipPositioner = fieldItemWorldPositionProvider;
        _chipSpriteChanger = chipSpriteChanger;
        _chipVisualProvider = fieldItemVisualProvider;
        _chipSpawner = fieldItemSpawner;
        _chipMovement = chipMovement;

    }

    public void SetupVisualization(int FieldSizeX, int FieldSizeY)
    {
        _chipPositioner.SetupChipParameters(FieldSizeX, FieldSizeY);
    }

    public void ShowEmptyGrid(int FieldSizeX, int FieldSizeY)
    {
        _fieldGridGenerator.ShowEmptyGrid(FieldSizeX, FieldSizeY);
    }

    public void ShowField(Field fieldData)
    {
        for (int x = 0; x < fieldData.Xsize; x++)
        {
            for (int y = 0; y < fieldData.Ysize; y++)
            {
                //_chipSpawner.SpawnChip(fieldData.FieldMatrix[x, y].ChipType, x, y);

                //var prefab = _chipPrefabProvider.GetPrefab(fieldData.FieldMatrix[x, y].ChipType);
                //var ChipGO = _chipSpawner.SpawnChip(prefab, Vector3.zero, ChipSize);
                //fieldData.FieldMatrix[x, y].ChipTransform = ChipGO.transform;
                //_chipMovement.Move(fieldData.FieldMatrix[x, y], x, y);
            }
        }

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(Field fieldData)
    {
        //Way to reset? clear all!
        Debug.Log("Field Resetted from field visualization");
    }
}