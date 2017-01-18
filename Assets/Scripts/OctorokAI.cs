using UnityEngine;
using System.Collections;

public class OctorokAI : MonoBehaviour {

    public GameObject bullet;


    private Transform bulletContainer;
    private Transform player;
    private Animator anim;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Link").transform;
        bulletContainer = GameObject.Find("Bullets").transform;
        anim = GetComponent<Animator>();
        StartCoroutine(Shoot());
	}
	
	// Update is called once per frame
	void Update () {
        LookAt(player);
	}

    public void LookAt(Transform target)
    {
        if (target && !anim.GetBool("Dead"))
        {
            Vector3 dir = (transform.position - target.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }
    }

    IEnumerator Shoot()
    {
        while(true && !anim.GetBool("Dead"))
        {
            GameObject bTemp = Instantiate(bullet, transform.position, Quaternion.identity, bulletContainer) as GameObject;
            bTemp.GetComponent<BulletScript>().direction = (player.position - transform.position);
            anim.SetTrigger("Shot");
            yield return new WaitForSeconds(3f);
        }
    }
}
