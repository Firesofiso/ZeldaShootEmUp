using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombarossaAI : MonoBehaviour {

    private Vector2 target;

    private Animator anim;
    private Rigidbody2D rigid;
    private EnemyScript enemy;
    private bool isExploding;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        enemy.speed = Random.Range(4f, 5f);
        StartCoroutine(Behavior());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Behavior()
    {
        while (!anim.GetBool("Dead") && enemy.speed != 0)
        {
            if (enemy.speed > 0)
            {
                enemy.speed -= 0.05f;
            } else
            {
                enemy.speed = 0;
            }
            rigid.velocity = new Vector3(0, -enemy.speed, 0);
            yield return null;
        }
        StartCoroutine(BombTimer());
    }


    IEnumerator BombTimer()
    {
        float timer = 0;
        while (!anim.GetBool("Dead") && !isExploding)
        {
            
            while (timer < 2)
            {
                yield return new WaitForSeconds(0.5f);
                anim.speed += 1f;
                timer += 0.5f;
            }

            anim.SetTrigger("Explode");

            isExploding = true;
            anim.speed = 1;
        }

    }

    public void SetTarget(Vector2 t)
    {
        target = t;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExploding)
        {
            if (collision.tag == "Player")
            {
                Player p = collision.GetComponent<Player>();
                p.TakeDamage(3);
            }
        }
    }
}
