using UnityEngine;

public class FieldVisualization : IFieldVisualization
{
    //Visualization Options. Like take from Scriptable object sprite
    //then Instantiate it properly
    //Set background

    public void ShowField(IField fieldData)
    {
        //Use Custom Visualizer to display Field. 
        //This can be a 2D sprite variant
        //This Can be 3D model
        //Debug mode?

        Debug.Log("Field Visualized from field visualization");
    }

    public void ResetField(IField fieldData)
    {
        //Way to reset? clear all!
        Debug.Log("Field Resetted from field visualization");
    }
}
