using UnityEngine;

public interface IUiPrefabProvider
{
    GameObject GetViewResourceAsync(UIViewType type);
}
