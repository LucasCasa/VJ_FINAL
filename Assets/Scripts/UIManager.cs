using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text P1Score;
    public Text P2Score;
    public Text StartText;
    private int[] scores = new int[2];
    private bool notStarted = true;
	private string P1text = "Red: ";
	private string P2text = "Blue: ";
	private bool multi;
	// Use this for initialization
	void Start () {
		multi = PlayerPrefs.GetString ("mode").ToLower ().Equals ("multi");
		if (!multi) {
			P2text = "Score: ";
			P1Score.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (notStarted && GameManager.Instance().IsStarted()) {
            Destroy(StartText);
            notStarted = false;
        }
		P2Score.text = P2text + GameManager.Instance().P2Score;
		if(multi)
			P1Score.text = P1text + GameManager.Instance().P1Score;
    }
}
