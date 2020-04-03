using Assets.Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Unity Properties
    public GameObject gObstacle;
    public GameObject gPrefabObstacle;
    #endregion

    #region Unity Events
    // Start is called before the first frame update
    void Start()
    {
        _initializeGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTick();
    }
    #endregion
    
    #region Object Properties
    public static GameManager gGameManager { get; set; }
    public GameState GameState { get; set; }
    private bool _gameRunning { get; set; }
    private bool _obstacleExists { get; set; }
    private double _life { get; set; } // 0 - 1
    private double _lifeDecInc { get; set; }
    private int _timer { get; set; } //seconds
    #endregion

    #region Public Method

    public void UpdateTick()
    {        
        if (_gameRunning)
        {
            if (_obstacleExists)
                DecreaseLife();

            if (IsGameOver())
                SetGameState(GameState.Lose);

            DecreaseTimer();
            if (_timer <= 0)
                SetGameState(GameState.Win);
        }
    }
    public bool IsGameOver()
    {        
        if (_life <= 0)
            return true;
        else
            return false;
    }
    public void DecreaseTimer()
    {        
        if(_gameRunning)
            _timer--;                            
    }

    public void DecreaseLife()
    {
        _life-= _lifeDecInc;
    }

    public void InstantiateObstacle()
    {
        //Instantiate Obstacle

        _obstacleExists = true;
    }

    public void ResetGame(int timer)
    {
        _timer = timer;
        _life = 1;
        _lifeDecInc = 0.01f;
    }

    public void PlayGame()
    {
        SetGameState(GameState.Play);
    }

    public void SetGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Idle:
                {                                        
                    break;
                }
            case GameState.Play:
                {
                    _gameRunning = true;
                    ResetGame(1000);
                    break;
                }
            case GameState.Lose:
                {
                    _gameRunning = false;
                    break;
                }
            case GameState.Win:
                {
                    _gameRunning = false;
                    break;
                }
        }        
    }
    #endregion

    #region Private Method
    private void _initializeGameManager()
    {
        GameManager.gGameManager = this;
        GameState = GameState.Idle;
    }
    #endregion
}
