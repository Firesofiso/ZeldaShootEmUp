using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyScript))]
public class TektiteAI : MonoBehaviour {

    private EnemyScript enemy;
    private Animator anim;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(JumpBehavior());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator JumpBehavior()
    {
        int leftChance = 50;
        int rightChance = 50;
        while (true && !anim.GetBool("Dead"))
        {
            anim.SetTrigger("Jump");
            leftChance = Mathf.RoundToInt((transform.position.x + 500 / 1000) * 100);
            rightChance = 100 - leftChance;
            int rand = Random.Range(0, 101);
            if (rand > 100 - rightChance)
            {
                rigid.velocity = new Vector3(Mathf.Sin(-225 * Mathf.Deg2Rad) * enemy.speed, Mathf.Cos(225 * Mathf.Deg2Rad) * enemy.speed, 0);
            } else if (rand < leftChance)
            {
                rigid.velocity = new Vector3(Mathf.Sin(225 * Mathf.Deg2Rad) * enemy.speed, Mathf.Cos(225 * Mathf.Deg2Rad) * enemy.speed, 0);
            }

            yield return new WaitForSeconds(0.5f);
            rigid.velocity = Vector3.zero;
            yield return new WaitForSeconds(1f);
        }
    }
}
