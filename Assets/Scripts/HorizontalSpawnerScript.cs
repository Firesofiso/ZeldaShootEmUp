using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HorizontalSpawnerScript : MonoBehaviour {

    public List<GameObject> enemies;
    public float startSpawnRate = 5f;
    public float spawnRate = 5f;
    public float range = 5f;
    public bool speedUp = false;

    //Game Control
    public GameManager gMan;
    public bool isSpawning;
    public bool storyReset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
