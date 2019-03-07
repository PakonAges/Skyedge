namespace GlobalMap
{
    public class GlobalMapController : IGlobalMapController
    {
        readonly IGlobalMapUIController _uIController;
        readonly IHeroSpawner _mapHeroSpawner;

        public GlobalMapController( IGlobalMapUIController globalMapUIController,
                                    IHeroSpawner mapHeroSpawner)
        {
            _uIController = globalMapUIController;
            _mapHeroSpawner = mapHeroSpawner;
        }

        public void InitGlobalMap()
        {
            _uIController.ShowGlobalMapHUDAsync();
            _mapHeroSpawner.SpawnHero();

            //Spawn Hero -> Position from save
            //In Region or Traveling
            //Calculate How far did he go, when I was online
            //Focus Camera On Hero
            //If Trying to Move Camera -> stop focusing
            
            //On Region Click -> Show Region Info
            //If Hero is not moving -> Can select Region to start movement
            //Start Movement -> Hero moving and time elapsed
            //On finish movement -> Can Enter Region
        }

        public void EnterRegion()
        {
            
        }
    }
}