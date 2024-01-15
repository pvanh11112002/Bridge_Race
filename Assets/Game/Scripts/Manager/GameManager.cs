using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Xem chi tiết trong ReadMe2.txt
public enum GameState
{
    MainMenu,
    GamePlay,
    Pause
}
public class GameManager : Singleton<GameManager>
{
    #region Khai  báo
    private GameState gameState;
    #endregion

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }
    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }
    public bool IsState(GameState gameState)
    {
        return this.gameState == gameState;
    }
}
