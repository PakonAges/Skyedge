public interface ILevelGenerator
{
    MatchLevel GenerateLevel(FieldGenerationRules Rules);
    void ResetLevel(MatchLevel Level, FieldGenerationRules Rules);
}
