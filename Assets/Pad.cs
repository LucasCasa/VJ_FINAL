using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(horizontal, 0, 0);
	}
    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log("Hit");
    }
}
