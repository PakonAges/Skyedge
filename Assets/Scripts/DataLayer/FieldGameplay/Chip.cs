public class Chip
{
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

    public bool IsMoveable
    {
        get { return (_movementComponent != null) ? true : false; }
    }

    public ChipType ChipType { get; }
    ChipMovement _movementComponent;
    NormalChipType _normalChip;

    //Field refference?
    //Is it MonoBehaviour?

    public Chip(int x, int y, ChipType chiptype)
    {
        X = x;
        Y = y;
        ChipType = chiptype;
    }

    public void MakeMoveable (ChipMovement moveableChip)
    {
        _movementComponent = moveableChip;
    }

    public void Move (int newX, int newY)
    {
        //Change coordinates in Grid/Field
        X = newX;
        Y = newY;

        //Move on the Display
        _movementComponent.Move(newX, newY);
    }
}