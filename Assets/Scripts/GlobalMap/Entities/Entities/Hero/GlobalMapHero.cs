namespace GlobalMap
{
    using UnityEngine;
    using Zenject;

    public class GlobalMapHero : MonoBehaviour, IGlobalMapHero
    {
        public Vector2 HeroPosition { get; set; }
        public GlobalMapHeroState State { get; set; }

    }
}