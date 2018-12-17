using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// setup of a field to generate. Used for debuging
/// </summary>
[CreateAssetMenu(menuName = "Data/Field/Generation Input")]
public class FieldGenerationInputSO : ScriptableObject
{
    //TODO
    //1. Make a global switch/mode selection to choose how to generate input parameters

    [Header("Field Size")]
    public int Xsize;
    public int Ysize;

    [Header("Background")]
    public Sprite BackgroundImage;

    [Header("Basic FIeld Items")]
    public List<NormalChipType> FieldItems;

    //Default items position
    //Win/lose conditions
    //Hero/enemies/loot
}
