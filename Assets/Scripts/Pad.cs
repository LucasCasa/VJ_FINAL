using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {
    public string movement;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis(movement) * Time.deltaTime;
        transform.position += new Vector3(horizontal*400*Time.deltaTime, 0, 0);
	}
}
