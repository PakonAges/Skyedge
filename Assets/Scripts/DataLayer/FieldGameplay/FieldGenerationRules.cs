using System.Collections.Generic;
using UnityEngine;

public class FieldGenerationRules
{
    public int Xsize { get; }
    public int Ysize { get; }
    public Sprite BackgroundImage { get; }
    public List<ChipType> ChipTypes;
    //Possible Items
    //Predefined position
    //Win/Lose Conditions
    //Hero/Enemies generation data

    public FieldGenerationRules(int x, int y, Sprite bgImg, List<ChipType> chips)
    {
        Xsize = x;
        Ysize = y;
        BackgroundImage = bgImg;
        ChipTypes = chips;
    }
}
