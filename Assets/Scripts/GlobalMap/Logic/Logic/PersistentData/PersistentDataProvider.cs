using UnityEngine;

namespace GlobalMap
{
    public class PersistentDataProvider : IPersistentDataProvider
    {
        readonly SOGlobalMapPersistantData _globalMapPersistantData;

        public PersistentDataProvider(SOGlobalMapPersistantData globalMapPersistantData)
        {
            _globalMapPersistantData = globalMapPersistantData;
        }

        public Vector2 GetHeroPosition()
        {
            return _globalMapPersistantData.GlobalMapHeroPosition;
        }
    }
}