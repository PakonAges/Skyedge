public class FieldGenerator : IFiledGenerator
{
    readonly IFieldGenerationRules rules;

    public FieldGenerator(IFieldGenerationRules rules)
    {
        this.rules = rules;
    }

    public IField GenerateField(IFieldGenerationRules rules)
    {
        var newField = new BasicField();


        return newField;
    }
}
