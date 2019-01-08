using UnityEngine;

public interface IChip
{
    //Board Position of the Chip
    int X { get; set; }
    int Y { get; set; }

    //Vector3 Position { set; }
    ChipType ChipType { get; set; }
    bool IsMovable { get; set; }
    //bool IsColored { get; set; }
    bool IsClearable { get; set; }

    GameObject MyGo { get; }
}
