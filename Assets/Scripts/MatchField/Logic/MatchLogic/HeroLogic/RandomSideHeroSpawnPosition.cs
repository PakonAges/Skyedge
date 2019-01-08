using UnityEngine;

public class RandomSideHeroSpawnPosition : IHeroSpawnStrategy
{
    readonly FieldFillDirection _fieldFillDirection;
    readonly int _fieldSizeX;
    readonly int _fieldSizeY;

    public RandomSideHeroSpawnPosition( FieldFillDirection fieldFillDirection,
                                        Field field)
    {
        _fieldFillDirection = fieldFillDirection;
        _fieldSizeX = field.Xsize;
        _fieldSizeY = field.Ysize;
    }

    public Vector2Int GetBoardPosition()
    {
        Vector2Int newPos = new Vector2Int();

        switch (_fieldFillDirection)
        {
            case FieldFillDirection.TopToBot:
            newPos.x = Random.Range(0, _fieldSizeX);
            newPos.y = 0;
            break;

            case FieldFillDirection.BotToTop:
            newPos.x = Random.Range(0, _fieldSizeX);
            newPos.y = _fieldSizeY - 1;
            break;

            case FieldFillDirection.LeftToRight:
            newPos.x = 0;
            newPos.y = Random.Range(0, _fieldSizeY);
            break;

            case FieldFillDirection.RightToLeft:
            newPos.x = _fieldSizeX - 1;
            newPos.y = Random.Range(0, _fieldSizeY);
            break;

            default:
            newPos.x = 0;
            newPos.y = 0;
            Debug.LogError("Can't Calculate Hero Position!");
            break;
        }

        return newPos;
    }
}
