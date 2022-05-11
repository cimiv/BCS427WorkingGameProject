using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public int playerHealth = 10;
	public static GameManager Instance;
	public GameState gameState;
	public static event Action<GameState> OnGameStateChanged;
	public TMP_Text healthbar;
	public GameObject losetext;
	public GameObject wintext;
	public GameObject player;
	public bool winCondition = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.Idle:
                break;
            case GameState.Playing:
                break;
            case GameState.GameOver:
                break;
            case GameState.WinLevel:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
	
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Idle;
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        healthbar.SetText("Health: " + playerHealth);
		
		if(playerHealth == 0)
		{
			losetext.SetActive(true);
			player.SetActive(false);
		}
		
		if(winCondition == true)
		{
			wintext.SetActive(true);
			player.SetActive(false);
		}
    }
}

public enum GameState
{
    Idle,
    Playing,
	GameOver,
    WinLevel
}
