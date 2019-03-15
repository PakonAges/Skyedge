using UnityEngine;

/// <summary>
/// Element of the Board: Color chip, Empty chip, Hero, Enemy
/// </summary>
public interface IChip
{
    ChipType ChipType { get; }

    //Board Position of the Chip
    int X { get; set; }
    int Y { get; set; }
    bool IsMovable { get; set; }
    bool IsClearable { get; set; }
    GameObject MyGo { get; }

    void InitChip(ChipType type, int Xpos, int Ypos, float Scale, Vector3 Position);
    void Dispose();
}
