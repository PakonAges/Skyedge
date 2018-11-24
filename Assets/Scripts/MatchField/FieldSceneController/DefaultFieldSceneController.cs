using UnityEngine;

/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController
{
    private readonly IFieldGenerator _fieldGenerator;
    private readonly IFieldGenerationRulesProvider _fieldGenerationRulesProvider;
    private readonly IFieldVisualization _fieldVisualization;

    public IField Field;

    public DefaultFieldSceneController(IFieldGenerator fieldGenerator,
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
        _fieldVisualization.ShowField(Field);
    }

    public void ResetField()
    {
        Field.Reset();
        _fieldVisualization.ResetField(Field);
    }
}
