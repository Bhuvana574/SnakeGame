
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum State
{
    Playing, Paused, Gameover
}

public static class GameState
{
    private static State gameState;
    public static Action OnGameOver;
    public static Action OnPaused;
    public static Action OnPlaying;
    public static State GetGameState()
    {
        return gameState;
    }
    public static void SetGameState(State state)
    {
        switch (state)
        {
            case State.Playing:
                SetStatePlaying();
                break;
            case State.Paused:
                SetStatePaused();
                break;
            case State.Gameover:
                SetStateGameover();
                break;
            default:
                break;

        }
    }

    private static void SetStateGameover()
    {
        gameState = State.Gameover;
        OnGameOver();
    }

    private static void SetStatePaused()
    {
        gameState = State.Paused;
        OnPaused();
    }

    private static void SetStatePlaying()
    {
        gameState = State.Playing;
        OnPlaying();
    }
}