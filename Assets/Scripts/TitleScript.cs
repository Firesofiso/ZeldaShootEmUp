using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

    public GameManager gMan;
	// Use this for initialization
	void Start () {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
	}

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Start") || Input.GetButtonDown("Submit"))
        {
            Application.LoadLevel("Main");
            gMan.storyMode = true;
            gMan.title = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
