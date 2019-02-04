public class LevelGenerator : ILevelGenerator
{
    public MatchLevel GenerateLevel(FieldGenerationRules Rules)
    {
        return new MatchLevel(Rules.TurnsLimit, Rules.LevelType);
    }

    public void ResetLevel(MatchLevel matchLevel, FieldGenerationRules Rules)
    {
        matchLevel.TurnsLimit = Rules.TurnsLimit;
        matchLevel.LevelType = Rules.LevelType;
    }
}
