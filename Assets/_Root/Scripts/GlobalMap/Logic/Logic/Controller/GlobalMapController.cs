namespace GlobalMap
{
    public class GlobalMapController : IGlobalMapController
    {
        readonly IHeroSpawner _mapHeroSpawner;

        public GlobalMapController( IHeroSpawner mapHeroSpawner)
        {
            _mapHeroSpawner = mapHeroSpawner;
        }

        public void InitGlobalMap()
        {
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