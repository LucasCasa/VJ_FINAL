using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
			
	}

    public void goToGame(){
        SceneManager.LoadScene("Game");
    }

	public void goToGameMulti() {
		PlayerPrefs.SetString ("mode", "multi");
		goToGame ();
	}

	public void goToGameSingle() {
		PlayerPrefs.SetString ("mode", "single");
		goToGame ();
	}

    public void exit(){
        Application.Quit();
    }
}
