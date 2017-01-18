using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Spawn()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Sin(Random.Range(0, 361) * Mathf.Deg2Rad) * 2, Mathf.Cos(Random.Range(0, 361) * Mathf.Deg2Rad) * 2, 0);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, -0.25f, 0);
    }
}
