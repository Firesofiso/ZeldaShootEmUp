using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyScript : MonoBehaviour {

    public int health = 3;
    public float speed = 2f;
    public int dmg; //Damage done when running into player.

    //public float timeout;
    //public string type;
    //public bool absorbing = false;

    public List<GameObject> pickUps; // pool of possible drops
    public List<float> dropRate;

    private Animator anim;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed, 0);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        anim = GetComponent<Animator>();
        //StartCoroutine(enemyTimeOut());
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destruction Zone")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(dmg);
            Destroy(gameObject);
        } else if (other.tag == "Bullets" && other.GetComponent<BulletScript>() && !other.GetComponent<BulletScript>().isEnemies)
        {

            EnemyScript enemy = GetComponent<EnemyScript>();
            BulletScript bullet = other.GetComponent<BulletScript>();
            enemy.health -= bullet.m_dmg;
            if (enemy.health <= 0)
            {
                anim.SetBool("Dead", true);
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Collider2D>().enabled = false;
                DropItems();
            }
            bullet.gameObject.SetActive(false);
        }

    }

	// Update is called once per frame
	void Update () {
	
	}

    public void Death()
    {
        Destroy(gameObject);
    }

    public void DropItems()
    {
        float rand;

        for (int i = 0; i < pickUps.Count; i++)
        {
            rand = Random.Range(0f, 100f);
            if (rand <= dropRate[i])
            {
                Instantiate(pickUps[i], transform.position, Quaternion.identity);
            }
        }
    }

    /*
   IEnumerator enemyTimeOut()
   {
       yield return new WaitForSeconds(timeout);
       Destroy(gameObject);
   }
   */
}
