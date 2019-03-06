namespace GlobalMap
{
    using UnityEngine;
    using Zenject;

    public class GlobalMapHero : MonoBehaviour, IGlobalMapHero
    {
        public Vector2 HeroPosition { get; set; }
        public GlobalMapHeroState State { get; set; }

        //public class Factory : PlaceholderFactory<GlobalMapHero> { }
    }

    public class GlobalMapHeroFactory : PlaceholderFactory<IGlobalMapHero> { }

    public enum GlobalMapHeroState
    {
        Invalid,
        Moving,
        InRegion
    }
}