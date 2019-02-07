using myUI;
using UnityEngine;

public class MatchEndViewModel : MyUIViewModel<MatchEndViewModel>
{
    public MatchEndView View { get { return IView as MatchEndView; } }
    public MatchEndViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    public void RestartLevel()
    {
        Debug.Log("Here should be the command to restart the game");
    }
}
