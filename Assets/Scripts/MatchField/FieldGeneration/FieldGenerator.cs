using UnityEngine;

public class FieldGenerator : IFieldGenerator
{

    public IField GenerateField(IFieldGenerationRules rules)
    {
        var NewField = new BasicField(rules.Xsize, rules.Ysize);

        for (int i = 0; i < rules.Ysize; i++)
        {
            for (int j = 0; j < rules.Xsize; j++)
            {
                var elementIndex = Random.Range(0, rules.NumberOfBasicElements);

                NewField.Field[i, j] = elementIndex;
            }
        }

        Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator",rules.Xsize, rules.Ysize, rules.NumberOfBasicElements);

        return NewField;
    }
}
