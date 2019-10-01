using myUI;
using UnityEngine;

public class ConfirmExitGameViewModel : MyUIViewModel<ConfirmExitGameViewModel, ConfirmExitGameView>
{
    public void ExitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}