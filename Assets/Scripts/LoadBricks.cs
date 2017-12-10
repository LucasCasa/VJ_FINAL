using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBricks : MonoBehaviour {
    public GameObject brickPrefab;
    public Texture2D bricksPosition;
    public List<ColorToPrefab> bricks;
    private Dictionary<Color, int> colorToIndex;
    
	// Use this for initialization
	void Start () {
        colorToIndex = new Dictionary<Color, int>();
		for(int i = 0; i<bricks.Count; i++) {
            colorToIndex.Add(bricks[i].color, i);
        }
        LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadLevel(int level) {
        for(int i = 0; i < bricksPosition.width; i++) {
            for(int j = 0; j < bricksPosition.height; j++) {
                SetBrick(i, j);
            }
        }
    }


    void SetBrick(int i, int j) {
        Color c = bricksPosition.GetPixel(i, j);
        if (!colorToIndex.ContainsKey(c) || c.a == 0) {
            return;
        }
        Sprite s = bricks[colorToIndex[c]].prefab;
        GameObject go = Instantiate(brickPrefab, new Vector3(i - bricksPosition.width / 2.0f, j /2.0f - bricksPosition.height / 4.0f, 0), new Quaternion(0, 0, 0, 0));
        go.GetComponent<SpriteRenderer>().sprite = s;
        go.GetComponent<Brick>().SetEffect(bricks[colorToIndex[c]].effect);
        go.GetComponent<Brick>().score = colorToIndex[c] + 1;
    }
}
