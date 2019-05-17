using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using Zenject;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace myUI
{
    public class MyUIAdressablePrefabProvider : IMyUIPrefabProvider, IInitializable
    {
        //Scene _uiScene;
        //public Scene UIScene
        //{
        //    get
        //    {
        //        if (_uiScene == null)
        //        {
        //            _uiScene = SceneManager.CreateScene("UI");
        //        }
        //        return _uiScene;
        //    }
        //}

        public void Initialize()
        {
            //_uiScene = SceneManager.CreateScene("UI");
        }

        public async Task<GameObject> GetWindowPrefab<T>() where T : IMyUIViewModel
        {
            try
            {
                var AssetName = ConvertGenericName(typeof(T).Name.ToString());
                AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(AssetName);
                await handle.Task;
                return handle.Result;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }

        }


        string ConvertGenericName(string ViewModelName)
        {
            int index = ViewModelName.Length - 5;
            return ViewModelName.Substring(0, index);
        }
    }
}
