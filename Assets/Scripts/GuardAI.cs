using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rigid;
    private EnemyScript enemy;

    private Vector3 leftSpot, rightSpot;
    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<EnemyScript>();
        leftSpot = new Vector3(-3, 2, 0);
        rightSpot = new Vector3(3, 2, 0);
        StartCoroutine(Behavior());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool WithinSpot(Vector3 target, float margin)
    {
        if (target.x < 0 &&
            transform.position.x <= target.x + margin &&
            transform.position.x >= target.x - margin &&
            transform.position.y >= target.y + margin &&
            transform.position.y <= target.y - margin)
        {
            return true;
        } else
        {
            return false;
        }
    }

    IEnumerator Behavior()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            targetPos = leftSpot;
        }
        else
        {
            targetPos = rightSpot;
        }

        
        int radial = 0;
        while (true && !anim.GetBool("Dead"))
        {

            //rigid.velocity = new Vector3(Mathf.Sin(radial * Mathf.Deg2Rad) * enemy.speed, Mathf.Cos(radial * Mathf.Deg2Rad) * enemy.speed, 0);
            //radial++;

            targetPos = new Vector3(Mathf.Sqrt(transform.position.y), Mathf.Pow(transform.position.x, 2), 0);
            rigid.velocity = (targetPos - transform.position).normalized * enemy.speed;
            

            /*
            if (targetPos.x < 0 && transform.position.x <= targetPos.x && transform.position.y >= targetPos.y ||
                targetPos.x > 0 && transform.position.x >= targetPos.x && transform.position.y >= targetPos.y) {
                rigid.velocity = Vector3.zero;
            }
            */
            yield return null;
        }
    }
}
