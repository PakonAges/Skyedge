using UnityEngine;

public class FieldVisualization : IFieldVisualization
{

    public void ShowField(IField fieldData)
    {
        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(IField fieldData)
    {
        Debug.Log("Field Resetted from field visualization");
    }
}
