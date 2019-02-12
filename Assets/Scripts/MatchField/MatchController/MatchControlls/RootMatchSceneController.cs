using UnityEngine;
using Zenject;

public class RootMatchSceneController : MonoBehaviour
{
    IMatchController _matchController;

    [Inject]
    public void Construct(IMatchController matchController)
    {
        _matchController = matchController;
    }

    void Start()
    {
        _matchController.StartMatchAsync();
    }
}
