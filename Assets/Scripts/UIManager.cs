using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text P1Score;
    public Text P2Score;

    private int[] scores = new int[2];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        P1Score.text = "Red: " + GameManager.Instance().P1Score;
        P2Score.text = "Blue: " + GameManager.Instance().P2Score;
    }
}
