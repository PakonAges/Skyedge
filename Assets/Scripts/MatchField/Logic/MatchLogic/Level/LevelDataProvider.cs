using UnityEngine;

public class LevelDataProvider : ILevelDataProvider
{
    private MatchLevel _level;
    public MatchLevel MatchLevel
    {
        get
        {
            if (_level == null)
            {
                Debug.LogError("Someine is Trying to get Level Data, when it's not here");
            }
            return _level;
        }

        set { _level = value; }
    }
}
