using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

    private Player p;

	// Use this for initialization
	void Start () {
        p = GameObject.Find("Link").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (p.curHP != p.GetMaxHP())
            {
                p.RecoverHealth(1);
            }
            Destroy(gameObject);
        }
        if (other.tag == "Destruction Zone")
        {
            Destroy(gameObject);
        }
    }
}
