namespace GlobalMap
{
    using UnityEngine;

    public interface IGlobalMapHero
    {
        Vector2 HeroPosition { get; set; }
        GlobalMapHeroState State { get; set; }
    }
}