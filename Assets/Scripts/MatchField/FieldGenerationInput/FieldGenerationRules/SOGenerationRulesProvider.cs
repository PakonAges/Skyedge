/// <summary>
/// Used for debuging. In real-life build should use another implementation of IFieldGenerationRulesProvider.
/// </summary>
public class SOGenerationRulesProvider : IFieldGenerationRulesProvider
{
    private SOFieldGenerationRules _fieldGenerationInputSO;

    public SOGenerationRulesProvider(SOFieldGenerationRules fieldGenerationInputSO)
    {
        _fieldGenerationInputSO = fieldGenerationInputSO;
    }

    public FieldGenerationRules GetGenerationRules()
    {
        var newRules = new FieldGenerationRules(    _fieldGenerationInputSO.Xsize,
                                                    _fieldGenerationInputSO.Ysize,
                                                    _fieldGenerationInputSO.BackgroundImage,
                                                    _fieldGenerationInputSO.Chips);
        return newRules;
    }
}
