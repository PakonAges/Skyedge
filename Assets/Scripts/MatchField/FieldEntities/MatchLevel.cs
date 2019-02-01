﻿using UnityEngine;

public class MatchLevel
{
    public int TurnsLimit { get; set; }
    public MatchLevelType LevelType { get; set; }
    public int CurrentTurn { get; private set; }

    public MatchLevel(int turns, MatchLevelType levelType)
    {
        CurrentTurn = 0;
        TurnsLimit = turns;
        LevelType = levelType;
    }

    //TO DO: Move to logic layer
    public void ResetLevel()
    {
        CurrentTurn = 0;
        Debug.LogFormat("Restart Level. Turns Left: {0}", TurnsLimit);
    }

    //TO DO: Move to logic layer
    public void EndOfPlayerMove()
    {
        CurrentTurn++;
        int TurnsLeft = TurnsLimit - CurrentTurn;

        if (TurnsLeft > 0)
        {
            Debug.LogFormat("Turns Left: {0}", TurnsLeft);
        }
        else
        {
            Debug.Log("Game Over. No more turns");
        }
    }
}