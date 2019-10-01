using System.Threading.Tasks;
using UnityEngine;

namespace myUI
{
    public interface IMyUIPrefabProvider
    {
        Task<GameObject> GetWindowPrefab<T>() where T : IMyUIViewModel;
    }
}
