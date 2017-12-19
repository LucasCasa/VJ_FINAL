using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Vector2 velocity = new Vector2(0, 5);
    private Rigidbody2D rb;
    public int playerId;
	private bool multi = false;
	// Use this for initialization
	void Start () {
        if (playerId == 0)
            velocity *= -1;
	}

    // Update is called once per frame
    void Update() {
        if (!GameManager.Instance().IsStarted())
            return;

        Debug.Log("Start Ball Movement");
        transform.position += (Vector3)(velocity * Time.deltaTime);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.09f, velocity, 0.1f, 2047);
        Debug.DrawRay(transform.position, velocity, Color.red);
        if (hit.collider != null) {
            Vector2 n;
            switch (hit.collider.gameObject.layer) {

                case 8:
                    hit.collider.gameObject.GetComponent<Brick>().Destroy(playerId);
                    n = hit.normal;
                    velocity = velocity - 2 * Vector2.Dot(velocity, n) * n;
                    break;
                case 9:
                    calculateCollision(hit.collider);
                    break;
				case 10:
				if (GameManager.Instance().multi || hit.collider.tag == "BlueGoal") {
						GameManager.Instance ().GameOver (hit.collider.tag == "BlueGoal" ? 1 : 0);
					} else {
						n = hit.normal;
						velocity = velocity - 2 * Vector2.Dot(velocity, n) * n;
					}
					break;
                default:
                    n = hit.normal;
                    velocity = velocity - 2 * Vector2.Dot(velocity, n) * n;
                    break;
            }
            Debug.Log("Hit: " + hit.collider);
            
        }
    }

    private void calculateCollision(Collider2D collider) {
        Debug.Log("Hit");
        if(collider.tag == "Player") {
            Debug.Log("Hit Pad");
            float magnitude = velocity.magnitude;
            float dir = -Mathf.Sign(velocity.y);
            float relativeDistanceToCenter = (transform.position.x - collider.transform.position.x) / (collider.bounds.size.x / 2);
            velocity = new Vector2(magnitude * Mathf.Sin(relativeDistanceToCenter * Mathf.PI / 3), dir*magnitude * Mathf.Cos(relativeDistanceToCenter * Mathf.PI / 3));
        }
        if(collider.tag == "Goals") {
            Debug.Log("Game Over");
        }
    }
}
