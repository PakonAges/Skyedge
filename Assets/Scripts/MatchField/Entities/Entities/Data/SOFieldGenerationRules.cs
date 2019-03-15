using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// setup of a field to generate. Used for debuging
/// </summary>
[CreateAssetMenu(menuName = "Data/Field/Generation Input")]
public class SOFieldGenerationRules : ScriptableObject
{
    //TODO
    //1. Make a global switch/mode selection to choose how to generate input parameters

    [Header("Field Size")]
    public int Xsize;
    public int Ysize;

    [Header("Background")]
    public Sprite BackgroundImage;

    [Header("Possible basic Chip Types")]
    public List<ChipType> Chips;

    [Header("Hero Spawn Position")]
    public HeroSpawnOption HeroSpawnOption;
    public Vector2Int ConcreteHeroSpawnPosition;

    [Header("Level Setup")]
    public int TurnsLimit;
    public MatchLevelType LevelType;
}
