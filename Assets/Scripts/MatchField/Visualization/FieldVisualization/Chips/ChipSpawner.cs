using UnityEngine;

public class ChipSpawner : MonoBehaviour, IChipSpawner
{
    //readonly Chip.Factory _chipFactory;
    readonly IChipPrefabProvider _chipPrefabProvider;
    readonly IChipPositionProvider _chipPositioner;
    
    public ChipSpawner(// Chip.Factory chipFactory,
                        IChipPrefabProvider chipPrefabProvider,
                        IChipPositionProvider chipPositionProvider)
    {
        //_chipFactory = chipFactory;
        _chipPrefabProvider = chipPrefabProvider;
        _chipPositioner = chipPositionProvider;
    }



    public GameObject SpawnChip(ChipType Chip, int Xpos, int Ypos)
    {
        var prefab = _chipPrefabProvider.GetPrefab(Chip);
        var pos = _chipPositioner.GetPosition(Xpos, Ypos);
        var newChip = Instantiate(prefab, pos, Quaternion.identity);


        return newChip;
    }

    public void SetupChip(Sprite Image, float Scale)
    {
        //?
    }

    //public GameObject SpawnChip(GameObject prefab, Vector3 position, float scale)
    //{
    //    var newItem = Instantiate(prefab, position, Quaternion.identity);
    //    newItem.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(scale, scale, 1);
    //    return newItem;
    //}
}
