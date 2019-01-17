using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using System;

public class UiPrefabProvider : IUiPrefabProvider
{
    GameObject window;

    public async Task<GameObject> GetViewResourceAsync(UIViewType type)
    {
        if (type == UIViewType.Invalid)
        {
            Debug.LogError("Trying to get Invalid UI Prefab");
            return null;
        }
        else
        {
            window = await Addressables.LoadAsset<GameObject>(type.ToString()) as GameObject;
            //Addressables.LoadAsset<GameObject>(type.ToString()).Completed += onLoadDone => { return window; };
            return window;
        }

        throw new System.NotImplementedException();
    }

    //void onLoadDone(UnityEngine.ResourceManagement.IAsyncOperation<GameObject> obj)
    //{
    //    window = obj.Result;
    //}
}
