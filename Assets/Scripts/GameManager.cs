using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player mainPlayer;

    public int rupees = 0;
    //public bool paused;

    //this is to make sure the instance of GameManager is kept through the game.
    public static GameManager instance = null;

    public GameObject pauseMenu;

    public bool title = true;
    public bool storyMode = false;
    public bool endlessMode = false;
    public bool foundLink = false;
    public bool paused = false;
    public int level = 0;


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if there is a GameManager that has been set
        if (instance == null)
        {
            //if not set this one as the GameManager
            instance = this;
        }
        else if (instance != this)
        {

            //if there is one set and it is different, delete this.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        //StartCoroutine(PauseCoroutine());
        
	}

    void FixedUpdate()
    {
     
    }

	// Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Link") != null && !foundLink)
        {
            mainPlayer = GameObject.Find("Link").GetComponent<Player>();
            StartCoroutine(PauseCoroutine());
            foundLink = true;
        }
    }

    public void reset()
    {

        if (endlessMode)
        {
            GameObject eList = GameObject.Find("Enemies");
            for (int i = 0; i < eList.transform.childCount; i++)
            {
                Destroy(eList.transform.GetChild(i).gameObject);
            }

            SpawnerScript spawner = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
            spawner.spawnRate = spawner.startSpawnRate;
            rupees = 0;
            mainPlayer.curHP = 3;
            mainPlayer.transform.position = new Vector3(0, -2, 0);
        }
        if (storyMode) {
            GameObject eList = GameObject.Find("Enemies");
            for (int i = 0; i < eList.transform.childCount; i++)
            {
                Destroy(eList.transform.GetChild(i).gameObject);
            }

            SpawnerScript spawner = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
            spawner.StopCoroutine("Story");
            spawner.storyReset = true;
            rupees = 0;
            mainPlayer.curHP = 3;
            mainPlayer.transform.position = new Vector3(0, -2, 0);
        }
    }

    IEnumerator PauseCoroutine()
    {

        while (true)
        {
            if (Input.GetButtonDown("Start") || Input.GetKeyDown("return"))
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    GetComponent<AudioSource>().volume = 0.35f;
                    pauseMenu.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    GetComponent<AudioSource>().volume = 0.10f;
                    pauseMenu.SetActive(true);
                }

            }
            yield return null;
        }
    }
}
