using System;
using UnityEngine;

public class HeroSpawner : IHeroSpawner
{
    readonly HeroChip.Factory _heroFactory;
    readonly IChipPositionProvider _chipPositioner;
    HeroChip _hero;

    public HeroSpawner( HeroChip.Factory factory,
                        IChipPositionProvider chipPositionProvider)
    {
        _heroFactory = factory;
        _chipPositioner = chipPositionProvider;
    }


    public IChip SpawnHero(int Xpos, int Ypos)
    {
        try
        {
            var newHero = _heroFactory.Create();
            newHero.name = "Hero";
            newHero.InitChip(ChipType.Hero, Xpos, Ypos, _chipPositioner.ChipSize, _chipPositioner.GetPosition(Xpos, Ypos));
            newHero.IsMovable = true;
            newHero.IsClearable = false;
            _hero = newHero;
            return newHero;
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to spawn HERO at [{0}:{1}]", Xpos, Ypos);
        }
        return null;
    }

    public void RemoveHero(HeroChip hero)
    {
        hero.Dispose();
        _hero = null;
    }
}
