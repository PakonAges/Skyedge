namespace GlobalMap
{
    using myUI;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Data/GlobalMap/Region Data")]
    public class GlobalMapRegionData : ScriptableObject, IMyUIViewData
    {
        public string RegionName;
    }

}