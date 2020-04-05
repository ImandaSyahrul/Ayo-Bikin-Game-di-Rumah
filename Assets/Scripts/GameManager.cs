using Assets.Scripts.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Debugging Purpose

    public bool IsExistsObstacle;

    #endregion

    #region Unity Properties

    public GameObject[] gObstacles;

    // public GameObject gPrefabObstacle;
    public ScrollBar ScrollBar;
    public ScrollBar ScrollKejenuhan;

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
    
    float elapsed = 0f;
    public static GameManager gGameManager { get; set; }
    public GameState GameState { get; set; }
    private bool _gameRunning { get; set; }
    public bool _obstacleExists { get; set; }
    private bool _obstacleAllowedToSpawn { get; set; }
    public double _life { get; set; } // 0 - 1
    private float _multiplierDec { get; set; }
    private TimeSpan _timer { get; set; } //seconds    
    private double _maxTimer { get; set; } //seconds    

    #endregion

    #region Public Method

    public void UpdateTick()
    {
        // For Debugging 
         // _obstacleExists = IsExistsObstacle;
        

        if (_gameRunning)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 3f) {
                elapsed = elapsed % 3f;
                InstantiateObstacle();
            }
            
            if (_obstacleExists)
                DecreaseLife();
            else
            {
                DecreaseLifeWithoutObstacle();
            }

            if (IsGameOver())
                SetGameState(GameState.Lose);

            DecreaseTimer();

            if (_timer.TotalSeconds <= 0)
                SetGameState(GameState.Win);

            ScrollBar.value = _timer.TotalSeconds / _maxTimer;
            ScrollKejenuhan.value = _life;
            ;
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
        if (_gameRunning)
            _timer = _timer.Subtract(new TimeSpan(0, 0, 0, 1, 0));
    }


    public void DecreaseLifeWithoutObstacle()
    {
        _life -= Time.deltaTime * 0.05f;
    }

    public void DecreaseLife()
    {
        _life -= Time.deltaTime * 0.1f;
    }

    public void InstantiateObstacle()
    {
        _obstacleAllowedToSpawn = false;
        Debug.Log(Random.Range(0, gObstacles.Length));
        gObstacles[Random.Range(0, gObstacles.Length)].SetActive(true);
        _obstacleExists = true;
    }

    public void IncreaseValueOfPlayer()
    {
        _life += Time.deltaTime * 0.025f;
    }

    public void ResetGame(TimeSpan timer)
    {
        _maxTimer = (int) timer.TotalSeconds;
        _timer = timer;
        _life = 1;
        _multiplierDec = 1.1f;
        _obstacleAllowedToSpawn = false;
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
                ResetGame(new TimeSpan(1, 0, 0));
                break;
            }
            case GameState.Lose:
            {
                Debug.Log("Loose");
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