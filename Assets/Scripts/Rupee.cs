using UnityEngine;
using System.Collections;

public class Rupee : MonoBehaviour {

    private GameManager gMan;
    public int rupeeValue;

    // Use this for initialization
    void Start()
    {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().GetRupee(rupeeValue);
            Destroy(gameObject);
        }
        if (other.tag == "Destruction Zone")
        {
            Destroy(gameObject);
        }
    }


}
