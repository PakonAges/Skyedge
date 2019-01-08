using UnityEngine;

public class Hero : IChip
{
    public Vector3 Position { set => throw new System.NotImplementedException(); }
    public ChipType ChipType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsMovable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsColored { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsClearable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
