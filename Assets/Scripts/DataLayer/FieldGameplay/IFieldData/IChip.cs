using UnityEngine;

public interface IChip
{
    ChipType ChipType { get; }

    //Board Position of the Chip
    int X { get; set; }
    int Y { get; set; }
    bool IsMovable { get; set; }
    bool IsClearable { get; set; }
    GameObject MyGo { get; }

    void InitChip(float Scale, Vector3 Position);
    void Dispose();
}
