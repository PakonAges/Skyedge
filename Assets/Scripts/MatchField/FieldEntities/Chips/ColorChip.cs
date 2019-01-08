using UnityEngine;
/// <summary>
/// Color is a generic chip to fill the board and do matches
/// </summary>
public class ColorChip : MonoBehaviour, IChip
{
    //IChip properties
    public int X { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Y { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ChipType ChipType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsMovable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsClearable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject MyGo => throw new System.NotImplementedException();

    //NormalChipProperties
    public ChipColor Color { get; set; }

}
