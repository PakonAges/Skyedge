public class LevelPauseState : ILevelState
{
    public void OnStateEnter()
    {
        //PauseGame
        //Show Pause Menu
        //Cut Scenes?
    }

    public void OnStateExit()
    {
        //ResumeGame == I need to remember my prev. State
        //Hide Pause Menu
    }
}
