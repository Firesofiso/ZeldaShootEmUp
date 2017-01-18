using UnityEngine;
using System.Collections;

public class HybridJellyBossScript : MonoBehaviour {

    public string name = "Hybrid Jelly";
    public float maxHealth = 30;
    public float health = 30;
    public float moveSpeed = 1f;
    public string type;

    public Rigidbody2D rigid;
    public GameObject canvas;
    public Animator anim;

    //prefabs
    public GameObject fireBullet, iceBullet;
    public GameObject healthBarPrefab, healthBar;
    public GameObject nameTextPrefab;

    public Transform bulletFront;

    //Patterns

    public bool entered = false;
    public bool normalPattern;
    public bool shot1;


	// Use this for initialization
	void Start () {
        normalPattern = true;
        

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector3(moveSpeed, 0, 0);
        rigid.freezeRotation = true;
        canvas = GameObject.Find("Canvas");

        healthBar = Instantiate(healthBarPrefab, new Vector3(5f, 2.75f, 0), Quaternion.identity) as GameObject;
        GameObject nameText = Instantiate(nameTextPrefab, new Vector3(4.5f, 2.5f, 0), Quaternion.identity) as GameObject;

        healthBar.transform.SetParent(canvas.transform);
        nameText.transform.SetParent(canvas.transform);
        healthBar.transform.localScale += new Vector3(750f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (entered == false)
        {
            if (gameObject.activeInHierarchy && transform.position.y < 1.25f)
            {
                rigid.velocity = new Vector3(0, 1, 0);
            }
            else
            {
                entered = true;
                rigid.velocity = new Vector3(moveSpeed, 0, 0);
                StartCoroutine(shotPattern1());
            }
        }
        if (normalPattern == true)
        {
            
            //Debug.Log("Boss X Position: " + transform.position.x);
            if (transform.position.x <= -3 || transform.position.x >= 3)
            {
                flipTypes();
                moveSpeed *= -1;
                rigid.velocity = new Vector3(moveSpeed, 0, 0);
                
            }

        }
	}

    public void flipTypes()
    {
        if (type == "Fire")
        {
            Debug.Log("Changed to ice");
            type = "Ice";
            anim.SetBool("IceForm", true);
        }
        else if (type == "Ice")
        {
            Debug.Log("Changed to fire");
            type = "Fire";
            anim.SetBool("IceForm", false);
        }
    }

    IEnumerator shotPattern1()
    {
        shot1 = true;
        while (shot1 == true)
        {
            if (type == "Fire")
            {
                GameObject frontBullet = Instantiate(fireBullet, bulletFront.position, Quaternion.identity) as GameObject;
                frontBullet.GetComponent<BulletScript>().m_speed *= -1;
            }
            else if (type == "Ice")
            {
                GameObject frontBullet = Instantiate(iceBullet, bulletFront.position, Quaternion.identity) as GameObject;
                frontBullet.GetComponent<BulletScript>().m_speed *= -1;
            }
            
            yield return new WaitForSeconds(3);
        }
    }
}
