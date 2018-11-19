public class FieldSceneController : IFieldSceneController
{
    private readonly IFieldGenerator _fieldGenerator;
    private readonly IFieldGenerationRulesProvider _fieldGenerationRulesProvider;
    private readonly IFieldVisualization _fieldVisualization;

    public IField Field;

    public FieldSceneController(IFieldGenerator fieldGenerator,
                                IFieldGenerationRulesProvider fieldGenerationRulesProvider,
                                IFieldVisualization fieldVisualization)
    {
        _fieldGenerator = fieldGenerator;
        _fieldGenerationRulesProvider = fieldGenerationRulesProvider;
        _fieldVisualization = fieldVisualization;
    }

    public void GenerateField()
    {
        Field = _fieldGenerator.GenerateField(_fieldGenerationRulesProvider.ProvideRules());
        //Visualize
    }

    public void ResetField()
    {
        Field.Reset();
    }
}
