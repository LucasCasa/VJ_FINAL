using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPreload : MonoBehaviour {

    void Awake() {
        GameObject check = GameObject.Find("GameManager");
        if (check == null) { UnityEngine.SceneManagement.SceneManager.LoadScene("_preload"); }
    }
}

