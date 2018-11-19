public class FieldGenerator : IFieldGenerator
{

    public IField GenerateField(IFieldGenerationRules rules)
    {
        var NewField = new BasicField(rules.Xsize, rules.Ysize);

        for (int i = 0; i < rules.Ysize; i++)
        {
            for (int j = 0; j < rules.Xsize; j++)
            {
                NewField.Field[i, j] = i; //hack
            }
        }

        return NewField;
    }
}
