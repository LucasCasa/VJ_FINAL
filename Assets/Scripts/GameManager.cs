using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    UIManager uiManager;
    private int[] scores = new int[2];
	public static bool multi = false;
    int loser = -1;

    bool gameStarted = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
        instance = this;
		multi = PlayerPrefs.GetString ("mode").ToLower().Equals ("multi");
	}
	
    public static GameManager Instance() {
        return instance;
    }

    public void AddScore(int playerId, int points) {
        scores[playerId] += points;
        BlockCount--;
        if(BlockCount == 0) {
            if (scores[0] > scores[1])
                GameOver(1);
            else if (scores[1] > scores[0])
                GameOver(0);
            else
                GameOver(-1);
        }
    }

    public void AttachUI(UIManager manager) {
        uiManager = manager;
    }
	// Update is called once per frame
	void Update () {
		if (!gameStarted) {
			Time.timeScale = 0;
		}
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().name == "Game") {
            gameStarted = true;
			Time.timeScale = 1;
        }
	}

    public bool IsStarted() {
        return gameStarted;
    }
    public int P1Score {
        get { return scores[0]; }
    }

    public int P2Score {
        get { return scores[1]; }
    }

	public int Loser { get { return loser; } }

    public int BlockCount { get; internal set; }

    internal void GameOver(int playerId) {
        loser = playerId;
        SceneManager.LoadScene("End");
        gameStarted = false;
    }
}
