using UnityEngine;

public class FieldGenerator : IFieldGenerator
{
    public IField GenerateField(IFieldGenerationRules rules)
    {
        var NewFieldData = new FieldData(rules.Xsize, rules.Ysize, rules.NumberOfBasicElements);
        var NewField = new BasicField(NewFieldData);

        for (int i = 0; i < NewFieldData.Ysize; i++)
        {
            for (int j = 0; j < NewFieldData.Xsize; j++)
            {
                var elementIndex = Random.Range(0, NewFieldData.NumberOfElements);

                NewFieldData.FieldMatrix[i, j] = elementIndex;
            }
        }

        Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator",rules.Xsize, rules.Ysize, rules.NumberOfBasicElements);

        return NewField;
    }
}
