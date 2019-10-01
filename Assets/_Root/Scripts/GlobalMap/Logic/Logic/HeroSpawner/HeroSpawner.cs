namespace GlobalMap
{
    public class HeroSpawner : IHeroSpawner
    {
        readonly HeroFactory _heroFactory;
        readonly IPersistentDataProvider _percistentData;
        readonly ICameraController _cameraController;

        public HeroSpawner(HeroFactory factory,
                                    IPersistentDataProvider percistentDataProvider,
                                    ICameraController cameraController)
        {
            _heroFactory = factory;
            _percistentData = percistentDataProvider;
            _cameraController = cameraController;
        }

        public IHero SpawnHero()
        {
            var Hero = _heroFactory.Create();
            Hero.HeroPosition = _percistentData.GetHeroPosition();
            _cameraController.FocusCamera(Hero.GetTransform());
            return Hero;
        }
    }
}