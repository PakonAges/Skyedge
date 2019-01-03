using System;
using UnityEngine;
using Zenject;

public class Chip : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
{
    IMemoryPool _pool;

    public Vector3 Position { set { transform.position = value; } } //Should change in Move method, not directly
    public float Scale
    {
        set
        {   GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(value, value, 1);
            GetComponent<BoxCollider2D>().size = new Vector2(value, value);
        }
    }

    public ChipType ChipType { get; set; }
    public NormalChipType NormalChipType { get; set; }
    public bool IsMovable { get; set; }
    public bool IsColored { get; set; }
    public bool IsClearable { get; set; }

    private int _x;
    public int X
    {
        get { return _x; }
        set { if (IsMovable) { _x = value; } }
    }

    private int _y;
    public int Y
    {
        get { return _y; }
        set { if (IsMovable) { _y = value; } }
    }

    public void InitChip(   ChipType type,
                            int Xpos,
                            int Ypos) //SHould move all inittialization here
    {
        this.ChipType = type;
        _x = Xpos;
        _y = Ypos;
    }


    public void OnSpawned(IMemoryPool pool)
    {
        _pool = pool;
        //Init
    }

    public void OnDespawned()
    {
        _pool = null;
        //reset
    }

    public void Dispose()
    {
        _pool.Despawn(this);
    }

    public class Factory : PlaceholderFactory<Chip> { }
}