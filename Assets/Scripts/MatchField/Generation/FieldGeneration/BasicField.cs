using UnityEngine;

public class BasicField : IField
{
    public Field FieldData { get; set; }
    
    public BasicField (Field fieldData)
    {
        FieldData = fieldData;
    }

    public void Reset()
    {
        Debug.Log("Field Data Reseted from Field class");
    }
}
