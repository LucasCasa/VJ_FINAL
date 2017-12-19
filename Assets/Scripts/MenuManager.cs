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
		GameManager.Instance ().multi = true;
		goToGame ();
	}

	public void goToGameSingle() {
		GameManager.Instance ().multi = false;
		goToGame ();
	}

	public void goToMenu() {
		SceneManager.LoadScene ("Menu");
	}

    public void exit(){
        Application.Quit();
    }
}
