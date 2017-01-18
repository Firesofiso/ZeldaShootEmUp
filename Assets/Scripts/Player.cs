using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    [HideInInspector]
    public double curHP = 3;
    private double maxHP = 3;
    public float maxSpeed = 10f;
    public float shotDelay = 0.25f;
    public float baseDelay = 0.25f;

    public bool canShoot = true;

    //PowerUps
    public bool isRapidFire = false;
    public List<GameObject> powerUps;

    public Transform shotPos;
    public GameObject bulletContainer;
    private List<GameObject> bullets = new List<GameObject>();

    private Animator anim;
    private LinkAudioHandler linkAudio;
    private GameManager gm;

    public double GetMaxHP()
    {
        return maxHP;
    }

    public void IncreaseMaxHP(int amount)
    {
        HUDScript hud = GameObject.Find("HUD").GetComponent<HUDScript>();
        maxHP++;
        curHP = maxHP;
        hud.RefreshHearts();
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        linkAudio = GetComponent<LinkAudioHandler>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        
        //Make the bullet list
        for (int i = 0; i < bulletContainer.transform.childCount; i++)
        {
            bullets.Add(bulletContainer.transform.GetChild(i).gameObject);
        }

    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);

        
    }

	// Update is called once per frame
	void Update () {

        if (curHP <= 0)
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().reset();
        }

        if (Input.GetButton("Fire1") && canShoot == true)
        {
            if (FindNextBullet() != null)
            {
                FindNextBullet().transform.position = shotPos.position;
                FindNextBullet().GetComponent<BulletScript>().direction = new Vector3(0, 1);
                FindNextBullet().SetActive(true);
                linkAudio.normalLasersAudio.PlayOneShot(linkAudio.normalLasersClip, Random.Range(0.25f, 0.75f));
                StartCoroutine(DelayShots());
            }
        }
    }

    GameObject FindNextBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }
        return null;
    }

    IEnumerator DelayShots()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }

    IEnumerator RapidFire()
    {
        HUDScript hud = GameObject.Find("Canvas").GetComponent<HUDScript>();
        if (isRapidFire == false)
        {
            isRapidFire = true;
            GameObject rF = Instantiate(powerUps[0], hud.powerUpPos.position, Quaternion.identity) as GameObject;
            shotDelay *= 0.5f;
            yield return new WaitForSeconds(5);
            shotDelay = baseDelay;
            isRapidFire = false;
            Destroy(rF);
        }
    }

    public void TakeDamage(int dmg)
    {
        HUDScript hud = GameObject.Find("HUD").GetComponent<HUDScript>();

        curHP -= dmg;
        linkAudio.hurtAudio.PlayOneShot(linkAudio.hurtClip, Random.Range(0.5f, 1f));
        anim.SetTrigger("TakeDamage");
        if (curHP <= 0)
        {
            curHP = 0;
        }
        hud.RefreshHearts();
    }

    public void RecoverHealth(int heal)
    {
        //Heal link here, from picking up hearts and such
        HUDScript hud = GameObject.Find("HUD").GetComponent<HUDScript>();
        if (curHP != maxHP)
        {
            if (curHP + heal <= maxHP)
            {
                linkAudio.pickUpHeartAudio.Play();
                curHP += heal;
            } else
            {
                curHP = maxHP;
            }
            hud.RefreshHearts();
        }
    }

    public void GetRupee(int value)
    {
        gm.rupees += value;
        linkAudio.pickUpRupeeAudio.Play();
    }
}
