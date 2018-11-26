using UnityEngine;

/// <summary>
/// Passing commands to change Global Field State. Doesn't care about implementation details of modules
/// </summary>
public class DefaultFieldSceneController : IFieldSceneController
{
    private readonly IFieldGenerator _fieldGenerator;
    private readonly IFieldDataProvider _fieldDataProvider;
    private readonly IFieldVisualization _fieldVisualization;

    public IField Field;

    public DefaultFieldSceneController( IFieldGenerator fieldGenerator,
                                        IFieldDataProvider fieldDataProvider,
                                        IFieldVisualization fieldVisualization)
    {
        _fieldGenerator = fieldGenerator;
        _fieldDataProvider = fieldDataProvider;
        _fieldVisualization = fieldVisualization;
    }

    public void GenerateField()
    {
        Field = _fieldGenerator.GenerateField(_fieldDataProvider.ProvideData());
        _fieldVisualization.ShowField(Field.FieldData);
    }

    public void ResetField()
    {
        Field.Reset();
        _fieldVisualization.ResetField(Field.FieldData);
    }
}
