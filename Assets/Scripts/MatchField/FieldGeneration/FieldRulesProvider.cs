public class FieldRulesProvider : IFieldGenerationRulesProvider
{
    IFieldGenerationRules _defaultRules;

    public FieldRulesProvider(IFieldGenerationRules nullRules)
    {
        _defaultRules = nullRules;
    }

    public IFieldGenerationRules ProvideRules()
    {
        //Rules definition logic
        var rules = new BasicGenerationRules(8, 8, 5);

        if (rules != null)
        {
            return rules;
        }
        else
        {
            return _defaultRules;
        }
    }
}
