using UnityEngine;
using Zenject;

public class GridCell : MonoBehaviour
{
    public Vector3 Position { set { transform.position = value; } }
    public Sprite Image { set { GetComponentInChildren<SpriteRenderer>().sprite = value; } }
    public float Scale { set { GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(value, value, 1); }  }

    public class Factory : PlaceholderFactory<GridCell>
    {
    }
}
