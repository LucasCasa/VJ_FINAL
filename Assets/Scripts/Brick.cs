using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    private GameObject particles;
    public int score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEffect(GameObject ps) {
        this.particles = ps;
    }
    public void Destroy(int player){
        GameManager.Instance().AddScore(player, score);
        Instantiate(particles,gameObject.transform.position, new Quaternion(0,0,0,0));
        gameObject.SetActive(false);
    }
}
