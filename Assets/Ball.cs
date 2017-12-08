using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag == "Player") {
            Debug.Log("Hit Pad");
            float magnitude = rb.velocity.magnitude;
            float dir = Mathf.Sign(rb.velocity.y);
            float relativeDistanceToCenter = (transform.position.x - collision.collider.transform.position.x) / (collision.collider.bounds.size.x / 2);
            rb.velocity = new Vector2(magnitude * Mathf.Sin(relativeDistanceToCenter * Mathf.PI / 3), dir*magnitude * Mathf.Cos(relativeDistanceToCenter * Mathf.PI / 3));
            Debug.Log("Relative distance: " + relativeDistanceToCenter);
            Debug.Log("Magnitude: " + magnitude);
            //rb.velocity = new Vector2(* 2, rb.velocity.y);
        }
        if(collision.collider.tag == "Goals") {
            Debug.Log("Game Over");
        }
    }
}
