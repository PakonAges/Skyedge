using System;
using UnityEngine;
using Zenject;

public class EmptyChip : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable, IChip
{
    //IChip properties
    public ChipType ChipType { get; private set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsMovable { get; set; }
    public bool IsClearable { get; set; }
    public GameObject MyGo { get { return gameObject; } }

    //Empty Chip properties
    IMemoryPool _pool;

    public void InitChip(ChipType type, int Xpos, int Ypos, float Scale, Vector3 Position)
    {
        ChipType = type;
        X = Xpos;
        Y = Ypos;

        //Setup Scale
        //GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(Scale, Scale, 1);
        //GetComponent<BoxCollider2D>().size = new Vector2(Scale, Scale);

        //Setup World Position
        MyGo.transform.position = Position;
    }

    public void Dispose()
    {
        _pool.Despawn(this);
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

    public class Factory : PlaceholderFactory<EmptyChip> { }
}
