using UnityEngine;

public class BasicField : IField
{
    public IFieldData FieldData { get; set; }

    public BasicField (IFieldData fieldData)
    {
        FieldData = fieldData;
    }

    public void Reset()
    {
        Debug.Log("Field Data Reseted from Field class");
    }
}
