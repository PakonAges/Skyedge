using UnityEngine;

public interface IChip
{
    Vector3 Position { set; }
    ChipType ChipType { get; set; }
    bool IsMovable { get; set; }
    bool IsColored { get; set; }
    bool IsClearable { get; set; }
}
