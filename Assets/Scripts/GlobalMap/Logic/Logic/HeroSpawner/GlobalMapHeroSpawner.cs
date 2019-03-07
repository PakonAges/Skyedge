namespace GlobalMap
{
    public class GlobalMapHeroSpawner : IGlobalMapHeroSpawner
    {
        readonly GlobalMapHeroFactory _heroFactory;

        public GlobalMapHeroSpawner(GlobalMapHeroFactory factory )
        {
            _heroFactory = factory;
        }

        public IGlobalMapHero SpawnHero()
        {
            return _heroFactory.Create();
        }
    }
}