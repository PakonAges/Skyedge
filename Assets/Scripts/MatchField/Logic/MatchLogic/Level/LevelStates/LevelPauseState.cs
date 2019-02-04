using UnityEngine;

public class LevelPauseState : ILevelState
{
    public ILevelController LevelController { get; set; }

    public void OnStateEnter()
    {
        Debug.Log("Enter Level Pause State");
        //PauseGame
        //Show Pause Menu
        //Cut Scenes?
    }

    public void OnStateExit()
    {
        Debug.Log("Level Pause State Exit");
        //ResumeGame == I need to remember my prev. State
        //Hide Pause Menu
    }
}
