using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {


    private GameManager gMan;
    public string type;
    public int rupeeValue;

	// Use this for initialization
	void Start () {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -0.25f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (type == "Rupee")
            {
                gMan.rupees += rupeeValue;
                GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
        }
        if (other.tag == "Destruction Zone")
        {
            Destroy(gameObject);
        }
    }
}
