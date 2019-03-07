namespace GlobalMap
{
    using UnityEngine;

    public interface IHero
    {
        Vector2 HeroPosition { get; set; }
        HeroState State { get; set; }
        Transform GetTransform();
    }

    public enum HeroState
    {
        Invalid,
        Moving,
        InRegion
    }
}