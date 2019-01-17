using System.Threading.Tasks;
using UnityEngine;

public interface IUiPrefabProvider
{
    Task<GameObject> GetViewResourceAsync(UIViewType type);
}
