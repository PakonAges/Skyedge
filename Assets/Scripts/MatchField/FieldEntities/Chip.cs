using UnityEngine;
using Zenject;

public class Chip : MonoBehaviour
{
    public Vector3 Position { set { transform.position = value; } } //Should change in Move method, not directly
    public float Scale
    {
        set
        {   GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(value, value, 1);
            GetComponent<BoxCollider2D>().size = new Vector2(value, value);
        }
    }
    public ChipType ChipType { get; set; }
    public Field MyField { get; set; }
    public bool IsMoveable { get; set; }
    public bool IsColored { get; set; }
    public NormalChipType NormalChipType { get; set; }

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

    public class Factory : PlaceholderFactory<Chip> { }
}