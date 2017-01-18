using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour {

    /* this is a script that will control the movements and the damage of bullets in the game */

    public bool isEnemies;
    public float m_speed;
    public int m_dmg;
    public float lifetime;

    [HideInInspector]
    public Vector3 direction;

    private Rigidbody2D rigid;

	// Use this for initialization
	void OnEnable () {
        StartCoroutine(Lifetime());
	}

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rigid.velocity = direction.normalized * m_speed;
	}

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        if (!isEnemies)
        {
            gameObject.SetActive(false);
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isEnemies)
        {

            Player player = other.GetComponent<Player>();
            player.TakeDamage(m_dmg);
            gameObject.SetActive(false);
        }
    }
}
