using UnityEngine;

public class RandomHeroSpawnPosition : IHeroSpawnStrategy
{
    readonly int _fieldSizeX;
    readonly int _fieldSizeY;

    public RandomHeroSpawnPosition (Field field)
    {
        _fieldSizeX = field.Xsize;
        _fieldSizeY = field.Ysize;
    } 

    public Vector2Int GetBoardPosition()
    {
        Vector2Int position = new Vector2Int
        {
            x = Random.Range(0, _fieldSizeX),
            y = Random.Range(0, _fieldSizeY)
        };

        return position;
    }
}
