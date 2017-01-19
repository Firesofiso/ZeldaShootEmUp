using UnityEngine;
using System.Collections;


//This is the movement script for Bats
//Bats movement in a wavy pattern.


public class BatScript : MonoBehaviour {

    private Rigidbody2D rigid;
    private Animator anim;
    private EnemyScript enemy;
    private Transform player;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyScript>();
        player = GameObject.Find("Link").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (!anim.GetBool("Dead"))
        {
            rigid.velocity = (player.position - transform.position).normalized * enemy.speed;
        }
	}
}
