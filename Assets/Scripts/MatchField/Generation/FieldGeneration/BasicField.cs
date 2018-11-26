using UnityEngine;

public class BasicField : IField
{
    public FieldData FieldData { get; set; }
    
    public BasicField (FieldData fieldData)
    {
        FieldData = fieldData;
    }

    public void Reset()
    {
        Debug.Log("Field Data Reseted from Field class");
    }
}
