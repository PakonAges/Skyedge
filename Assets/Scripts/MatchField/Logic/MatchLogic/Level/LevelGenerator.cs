public class LevelGenerator : ILevelGenerator
{
    readonly IFieldCleaner _fieldCleaner;
    readonly ILevelDataProvider _levelDataProvider;
    MatchLevel _Level { get { return _levelDataProvider.MatchLevel; } }


    public LevelGenerator(  IFieldCleaner fieldCleaner,
                            ILevelDataProvider levelDataProvider)
    {
        _fieldCleaner = fieldCleaner;
        _levelDataProvider = levelDataProvider;
    }

    public void GenerateLevel(FieldGenerationRules Rules)
    {
        _levelDataProvider.MatchLevel = new MatchLevel(Rules.TurnsLimit, Rules.LevelType);
    }

    public void ResetLevel(FieldGenerationRules Rules)
    {
        _fieldCleaner.ClearAllBoard();
        _Level.TurnsLimit = Rules.TurnsLimit;
        _Level.LevelType = Rules.LevelType;
    }
}
