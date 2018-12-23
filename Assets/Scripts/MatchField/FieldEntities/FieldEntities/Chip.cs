using UnityEngine;
using Zenject;

public class Chip : MonoBehaviour, IChip
{
    public Vector3 Position { set { transform.position = value; } } //Shpuld change in Move method, not directly
    public float Scale { set { GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(value, value, 1); } }
    public ChipType ChipType { get; set; }
    public Field MyField { get; set; }
    public IChipMovement ChipMovemet { get; set; }

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
        get; set;
    }

    public void Move (int newX, int newY)
    {
        //Change coordinates in Grid/Field
        X = newX;
        Y = newY;

        //Move on the Display
        //_movementComponent.Move(newX, newY);
    }

    public class Factory : PlaceholderFactory<Chip> { }
}