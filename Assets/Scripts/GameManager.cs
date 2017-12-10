using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager instance;
    UIManager uiManager;
    private int[] scores = new int[2];
    int looser = -1;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(1);
        instance = this;
	}
	
    public static GameManager Instance() {
        return instance;
    }

    public void AddScore(int playerId, int points) {
        scores[playerId] += points;
    }

    public void AttachUI(UIManager manager) {
        uiManager = manager;
    }
	// Update is called once per frame
	void Update () {
		
	}

    public int P1Score {
        get { return scores[0]; }
    }

    public int P2Score {
        get { return scores[1]; }
    }

    public int Looser { get { return looser; } }

    internal void GameOver(int playerId) {
        looser = playerId;
        SceneManager.LoadScene("End");
    }
}
