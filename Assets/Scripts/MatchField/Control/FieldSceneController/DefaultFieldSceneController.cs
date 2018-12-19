/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController
{
    private readonly IFieldGenerator _fieldGenerator;
    private readonly IFieldVisualization _fieldVisualization;

    private readonly FieldGenerationRules _fieldGenerationRules;

    public Field GameField;

    public DefaultFieldSceneController( IFieldGenerator fieldGenerator,
                                        IFieldGenerationRulesProvider fieldDataProvider,
                                        IFieldVisualization fieldVisualization)
    {
        _fieldGenerator = fieldGenerator;
        _fieldVisualization = fieldVisualization;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();
    }

    public void GenerateField()
    {
        ShowBackGround();
        GameField = _fieldGenerator.GenerateField(_fieldGenerationRules);
        _fieldVisualization.ShowField(GameField); // or _fieldGenerationRules?
    }

    public void ShowBackGround()
    {
        _fieldVisualization.ShowBackGround(_fieldGenerationRules.BackgroundImage);
        _fieldVisualization.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void ResetField()
    {
        //Field.Reset();
        //_fieldVisualization.ResetField(Field.FieldData);
    }
}
