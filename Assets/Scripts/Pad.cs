﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour {
    public string movement;
	private float minPos;
	private float maxPos;

	// Use this for initialization
	void Start () {
		float size = ((BoxCollider2D)gameObject.GetComponent<BoxCollider2D>()).size.x;
		minPos = GameObject.Find ("LeftWall").transform.position.x + size/2;
		maxPos = GameObject.Find ("RightWall").transform.position.x - size/2;
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis(movement);
        transform.position += new Vector3(horizontal*10*Time.deltaTime, 0, 0);
		if (transform.position.x < minPos) {
			transform.position -= new Vector3(transform.position.x-minPos,0,0);
		} else if (transform.position.x > maxPos) { 
			transform.position -= new Vector3(transform.position.x-maxPos,0,0);
		}
	}
}
