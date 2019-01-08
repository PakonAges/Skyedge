using UnityEngine;

public class PresetHeroSpawnPosition : IHeroSpawnStrategy
{
    readonly int _xPos;
    readonly int _yPos;

    public PresetHeroSpawnPosition(int x, int y)
    {
        _xPos = x;
        _yPos = y;
    }


    public Vector2Int GetBoardPosition()
    {
        return new Vector2Int { x = _xPos,
                                y = _yPos};
    }
}
