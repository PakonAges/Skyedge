using UnityEngine;

public class FieldGenerator : IFieldGenerator
{
    public IField GenerateField(FieldData fieldData)
    {
        var NewField = new BasicField(fieldData);

        for (int i = 0; i < fieldData.Ysize; i++)
        {
            for (int j = 0; j < fieldData.Xsize; j++)
            {
                var elementIndex = Random.Range(0, fieldData.NumberOfElements);

                fieldData.FieldMatrix[i, j] = elementIndex;
            }
        }

        Debug.LogFormat("Field [{0},{1}] with {2} elements Generated in Field Generator",fieldData.Xsize, fieldData.Ysize, fieldData.NumberOfElements);

        return NewField;
    }
}
