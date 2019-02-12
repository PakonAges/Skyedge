public class LevelGenerator : ILevelGenerator
{
    readonly IFieldCleaner _fieldCleaner;

    public LevelGenerator(IFieldCleaner fieldCleaner)
    {
        _fieldCleaner = fieldCleaner;
    }

    public MatchLevel GenerateLevel(FieldGenerationRules Rules)
    {
        return new MatchLevel(Rules.TurnsLimit, Rules.LevelType);
    }

    public void ResetLevel(MatchLevel matchLevel, FieldGenerationRules Rules)
    {
        _fieldCleaner.ClearAllBoard();
        matchLevel.TurnsLimit = Rules.TurnsLimit;
        matchLevel.LevelType = Rules.LevelType;
    }
}
