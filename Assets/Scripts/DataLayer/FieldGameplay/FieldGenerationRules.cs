using System.Collections.Generic;
using UnityEngine;

public class FieldGenerationRules
{
    public int Xsize { get; }
    public int Ysize { get; }
    public Sprite BackgroundImage { get; }
    public List<ChipType> ChipTypes;
    public HeroSpawnOption HeroSpawnOption;
    public Vector2Int ConcreteHeroSpawnPosition;
    //Possible Items
    //Predefined position
    //Win/Lose Conditions
    //Enemies generation data

    public FieldGenerationRules(int x, int y, Sprite bgImg, List<ChipType> chips, HeroSpawnOption heroSpawnOption, Vector2Int concreteHeroSpawnPosition)
    {
        Xsize = x;
        Ysize = y;
        BackgroundImage = bgImg;
        ChipTypes = chips;
        HeroSpawnOption = heroSpawnOption;
        ConcreteHeroSpawnPosition = concreteHeroSpawnPosition;
    }

    public Vector2Int GetHeroSpawnPosition()
    {
        Vector2Int Position = new Vector2Int(0, 0);

        switch (HeroSpawnOption)
        {
            case HeroSpawnOption.Random:
            Position.x = Random.Range(0, Xsize);
            Position.y = Random.Range(0, Ysize);
            break;

            case HeroSpawnOption.Concrete:
            return ConcreteHeroSpawnPosition;

            case HeroSpawnOption.RandomLeftSide:
            Position.x = 0;
            Position.y = Random.Range(0, Ysize);
            break;

            case HeroSpawnOption.RandomRightSide:
            Position.x = Xsize - 1;
            Position.y = Random.Range(0, Ysize);
            break;

            case HeroSpawnOption.RandomTopSide:
            Position.x = Random.Range(0, Xsize);
            Position.y = 0;
            break;

            case HeroSpawnOption.RandomBotSide:
            Position.x = Random.Range(0, Xsize);
            Position.y = Ysize - 1;
            break;

            default:
            break;
        }

        return Position;
    }
}
