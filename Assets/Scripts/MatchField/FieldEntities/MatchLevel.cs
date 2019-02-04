public class MatchLevel
{
    public int TurnsLimit { get; set; }
    public MatchLevelType LevelType { get; set; }
    public int CurrentTurn { get; set; }

    public MatchLevel(int turns, MatchLevelType levelType)
    {
        CurrentTurn = 0;
        TurnsLimit = turns;
        LevelType = levelType;
    }
}