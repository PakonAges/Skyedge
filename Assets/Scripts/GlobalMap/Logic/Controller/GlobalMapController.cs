namespace GlobalMap
{
    public class GlobalMapController : IGlobalMapController
    {
        readonly IGlobalMapUIController _uIController;

        public GlobalMapController(IGlobalMapUIController globalMapUIController)
        {
            _uIController = globalMapUIController;
        }

        public void InitGlobalMap()
        {
            _uIController.ShowGlobalMapHUDAsync();
        }

        public void EnterRegion()
        {

        }
    }
}