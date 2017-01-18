using UnityEngine;
using System.Collections;


//This is the movement script for Bats
//Bats movement in a wavy pattern.


public class BatScript : MonoBehaviour {

    private Rigidbody2D rigid;
    private Animator anim;

    public bool flipped;


    //patterns
    public bool normal, swoop, looping;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!anim.GetBool("Dead"))
        {
            if (normal)
            {
                if (!flipped)
                {
                    rigid.velocity = new Vector3(5 * Mathf.Sin(transform.position.y * 2), rigid.velocity.y, 0);
                }
                else if (flipped)
                {
                    rigid.velocity = new Vector3(-5 * Mathf.Sin(transform.position.y * 2), rigid.velocity.y, 0);
                }
            }
            else if (swoop)
            {
                if (transform.position.x < 0)
                {
                    rigid.velocity = new Vector3(2, -Mathf.Pow(transform.position.x, 2), 0);
                }
                else
                {
                    rigid.velocity = new Vector3(2, Mathf.Pow(transform.position.x, 2), 0);
                    if (transform.position.y >= 2)
                    {
                        rigid.velocity = new Vector3(0, 0, 0);
                        looping = true;
                        swoop = false;
                    }
                }
            }
            else if (looping)
            {
                StartCoroutine("loopTime");
                rigid.velocity = new Vector3(-4f * Mathf.Sin(transform.position.y * 3f), -4f * Mathf.Cos(transform.position.x * 3f), 0);
            }
        }
	}

    IEnumerator loopTime()
    {
        yield return new WaitForSeconds(1.5f);
        looping = false;
        rigid.velocity = new Vector3(0, -4, 0);
    }
}
