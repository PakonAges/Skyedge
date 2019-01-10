using System;
using UnityEngine;
using Zenject;

public class Hero : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable, IChip
{
    //IChip properties
    public ChipType ChipType { get; private set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsMovable { get; set; }
    public bool IsClearable { get; set; }
    public GameObject MyGo { get { return gameObject; } }

    //Hero Properties
    IMemoryPool _pool;

    public void InitChip(ChipType type, int Xpos, int Ypos, float Scale, Vector3 Position)
    {
        ChipType = type;
        X = Xpos;
        Y = Ypos;

        //Setup Scale
        var sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            sr.transform.localScale = new Vector3(Scale, Scale, 1);
        }
        else
        {
            Debug.LogError("Trying to Find SpriteRenderer but can't");
        }

        var col = GetComponent<BoxCollider2D>();
        if (col != null)
        {
            GetComponent<BoxCollider2D>().size = new Vector2(Scale, Scale);
        }
        else
        {
            Debug.LogError("Trying to Find Collider but can't");
        }

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

    public class Factory : PlaceholderFactory<Hero> { }
}
