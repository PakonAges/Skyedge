using UnityEngine;

public interface IUiPrefabProvider
{
    GameObject GetViewResource(UIViewType type);
}
