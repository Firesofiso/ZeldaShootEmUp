using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUDScript : MonoBehaviour {

    public Transform powerUpPos;
    public Text score;

    public GameObject filledHeartParent, emptyHeartParent;
    [HideInInspector]
    public List<GameObject> fullHearts, emptyHearts;

    private Player mainPlayer;
    private GameManager gMan;

	// Use this for initialization
	void Start () {
        mainPlayer = GameObject.Find("Link").GetComponent<Player>();
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
        FillHeartLists();
        RefreshHearts();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "" + gMan.rupees;
	}
    
    void FillHeartLists()
    {
        fullHearts = new List<GameObject>();
        emptyHearts = new List<GameObject>();
        for (int i = 0; i < emptyHeartParent.transform.childCount; i++)
        {
            fullHearts.Add(filledHeartParent.transform.GetChild(i).gameObject);
            emptyHearts.Add(emptyHeartParent.transform.GetChild(i).gameObject);
        }
    }

    public void RefreshHearts()
    {
        double filledHeartCount = mainPlayer.curHP;
        double emptyHeartCount = mainPlayer.GetMaxHP();

        for (int i = 0; i < emptyHearts.Count; i++)
        {
            fullHearts[i].SetActive(false);
            emptyHearts[i].SetActive(false);
        }

        for (int i = 0; i < emptyHeartCount; i++)
        {
            if (i < filledHeartCount && filledHeartCount != 0)
            {
                fullHearts[i].SetActive(true);
            }
            emptyHearts[i].SetActive(true);
        }
    }
}
