using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace myUI
{
    public interface IMyUIPrefabProvider
    {
        Scene UIScene { get; }
        Task<GameObject> GetWindowPrefab<T>() where T : MyUIViewModel;
    }
}
