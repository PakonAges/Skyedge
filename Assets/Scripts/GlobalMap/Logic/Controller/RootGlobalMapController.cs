using UnityEngine;
using Zenject;

namespace GlobalMap
{
    public class RootGlobalMapController : MonoBehaviour
    {
        IGlobalMapController _globalMapController;

        [Inject]
        public void Construct(IGlobalMapController globalMapController)
        {
            _globalMapController = globalMapController;
        }

        void Start()
        {
            _globalMapController.InitGlobalMap();
        }
    }
}