/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController
{
    readonly IFieldBGSetup _fieldBGSetup;
    readonly IFieldGenerator _fieldGenerator;
    readonly IFieldVisualization _fieldVisualization;

    readonly FieldGenerationRules _fieldGenerationRules;

    public Field GameField;

    public DefaultFieldSceneController( IFieldBGSetup fieldBGSetup,
                                        IFieldGenerator fieldGenerator,
                                        IFieldGenerationRulesProvider fieldDataProvider,
                                        IFieldVisualization fieldVisualization)
    {
        _fieldBGSetup = fieldBGSetup;
        _fieldGenerator = fieldGenerator;
        _fieldVisualization = fieldVisualization;
        _fieldGenerationRules = fieldDataProvider.GetGenerationRules();
    }

    public void GenerateField()
    {
        ShowBackGround();

        GameField = _fieldGenerator.GenerateField(_fieldGenerationRules);
        //_fieldVisualization.ShowField(GameField); // or _fieldGenerationRules?
    }

    public void ShowBackGround()
    {
        _fieldBGSetup.SetupBackGround(_fieldGenerationRules.BackgroundImage);
        _fieldVisualization.ShowEmptyGrid(_fieldGenerationRules.Xsize, _fieldGenerationRules.Ysize);
    }

    public void ResetField()
    {
        //Field.Reset();
        //_fieldVisualization.ResetField(Field.FieldData);
    }
}
