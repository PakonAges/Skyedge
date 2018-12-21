using UnityEngine;
using Zenject;

public class Chip
{
    public Transform ChipTransform { get; set; }

    private int _x;
    public int X
    {
        get { return _x; }
        set { if (IsMoveable) { _x = value; } }
    }

    private int _y;
    public int Y
    {
        get { return _y; }
        set { if (IsMoveable) { _y = value; } }
    }
    public bool IsMoveable {
        //get { return (_movementComponent != null) ? true : false; }
        get; set; }

    public ChipType ChipType { get; }
    //NormalChipType _normalChip;

    //IChipMovement _movementComponent;

    //Field refference?

    public Chip(int x, int y, ChipType chiptype)
    {
        X = x;
        Y = y;
        ChipType = chiptype;

        if (chiptype == ChipType.NormalChip)
        {
            //_movementComponent = new ChipMovement(ChipTransform);
        }
    }

    public void Move (int newX, int newY)
    {
        //Change coordinates in Grid/Field
        X = newX;
        Y = newY;

        //Move on the Display
        //_movementComponent.Move(newX, newY);
    }

    //public class Factory : PlaceholderFactory<Chip> { }
}