using UnityEngine;

public class BasicField : IField
{
    public int[,] Field;

    public BasicField (int Xsize, int Ysize)
    {
        Field = new int[Xsize, Ysize];
    }

    public void Reset()
    {
        Debug.Log("Field Data Reseted from Field class");
    }
}
