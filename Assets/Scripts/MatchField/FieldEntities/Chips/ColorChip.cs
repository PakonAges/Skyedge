using System;
using UnityEngine;
using Zenject;

/// <summary>
/// Color is a generic chip to fill the board and do matches
/// </summary>
public class ColorChip : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable, IChip
{
    //IChip properties
    ChipType _chipType;
    public ChipType ChipType
    {
        get {return _chipType; }
        private set { _chipType = ChipType.ColorChip; }
    }

    public int X { get; set; }
    public int Y { get; set; }
    public bool IsMovable { get; set; }
    public bool IsClearable { get; set; }
    public GameObject MyGo { get { return gameObject; } }

    //Color Chip Properties
    public ChipColor Color { get; set; }
    IMemoryPool _pool;

    public void Dispose()
    {
        _pool.Despawn(this);
    }

    public void InitChip(int Xpos, int Ypos, float Scale, Vector3 Position)
    {
        X = Xpos;
        Y = Ypos;
        //Setup Scale
        GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(Scale, Scale, 1);
        GetComponent<BoxCollider2D>().size = new Vector2(Scale, Scale);

        //Setup World Position
        MyGo.transform.position = Position;
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

    public class Factory : PlaceholderFactory<ColorChip> { }
}
