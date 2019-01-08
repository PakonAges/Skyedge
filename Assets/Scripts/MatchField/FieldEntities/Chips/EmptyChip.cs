using UnityEngine;

public class EmptyChip : IChip
{
    public int X { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Y { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ChipType ChipType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsMovable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsClearable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public GameObject MyGo => throw new System.NotImplementedException();

    GameObject IChip.MyGo => throw new System.NotImplementedException();
}
