using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

    public List<GameObject> enemies;
    public List<GameObject> bosses;
    public float startSpawnRate = 5f;
    public float spawnRate = 5f;
    public float range = 5f;
    
    //Game Control
    public GameManager gMan;
    public bool isSpawning;
    public bool storyReset;


	// Use this for initialization
	void Start () {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(Spawning());
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator Spawning()
    {
        //isSpawning = true;
        while(isSpawning == true) {
            int randEnemy = Random.Range(0, enemies.Count);
            Vector3 randomPos = new Vector3(Random.Range(transform.position.x - range, transform.position.x + range), transform.position.y, 0);
            GameObject newEnemy = Instantiate(enemies[randEnemy], randomPos, Quaternion.identity) as GameObject;
            newEnemy.transform.SetParent(GameObject.Find("Enemies").transform);
            yield return new WaitForSeconds (spawnRate);
        }
    }


    /*
     * I lost pretty much all of the graphics for this old stuff so it broke everything.
    IEnumerator Story()
    {

        //Play some intro thingy or whatever
        //Story story
        //plot plot
        yield return new WaitForSeconds(1);


        float spawnPos;

        //Spawn enemies in a set pattern
        //Spawn three jellys in a v pattern, one blue two red.
        
        GameObject redJelly1 = Instantiate(enemies[1], new Vector3(transform.position.x - 0.25f, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly1.transform.SetParent(GameObject.Find("Enemies").transform);
        GameObject redJelly2 = Instantiate(enemies[1], new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly2.transform.SetParent(GameObject.Find("Enemies").transform);
        
        GameObject iceJelly = Instantiate(enemies[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);
        
        yield return new WaitForSeconds(0.5f);


        //Choo-choo
        //All aboard the bat train!
        GameObject batTrain1;
        GameObject batTrain2;
        for (int i = 0; i < 5; i++)
        {
            batTrain1 = Instantiate(enemies[4], new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity) as GameObject;
            batTrain1.transform.SetParent(GameObject.Find("Enemies").transform);
            batTrain2 = Instantiate(enemies[4], new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity) as GameObject;
            batTrain2.transform.SetParent(GameObject.Find("Enemies").transform);
            batTrain2.GetComponent<BatScript>().flipped = true;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2);

        //Spawn three jellys in a v pattern, one blue two red.
        redJelly1 = Instantiate(enemies[1], new Vector3(transform.position.x - 0.25f - 2, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly1.transform.SetParent(GameObject.Find("Enemies").transform);
        redJelly2 = Instantiate(enemies[1], new Vector3(transform.position.x + 0.25f - 2, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly2.transform.SetParent(GameObject.Find("Enemies").transform);
        iceJelly = Instantiate(enemies[0], new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);


        yield return new WaitForSeconds(5);
        
        GameObject leftJellies;
        GameObject rightJellies;
        
        float displacement = 0.33f;
        
        for (int i = 0; i < 5; i++)
        {
            leftJellies = Instantiate(enemies[0], new Vector3(transform.position.x - 2 - (i * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
            leftJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            rightJellies = Instantiate(enemies[1], new Vector3(transform.position.x + 2 + (i * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
            rightJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            yield return new WaitForSeconds(0.9f);
        }
        displacement = -0.33f;
        for (int i = 0; i < 5; i++)
        {
            leftJellies = Instantiate(enemies[0], new Vector3(transform.position.x - 3.32f - (i * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
            leftJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            rightJellies = Instantiate(enemies[1], new Vector3(transform.position.x + 3.32f + (i * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
            rightJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            yield return new WaitForSeconds(0.9f);
        }

        yield return new WaitForSeconds(10);
        

        //Anti-Fairies
        displacement = 0.33f;
        int countLeft = 14;
        int countRight = 14;
        for (int i = 0; i < 39; i++)
        {
            for (int j = 0; j < countLeft; j++)
            {
                leftJellies = Instantiate(enemies[7], new Vector3(transform.position.x - 5f + (j * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
                leftJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            }
            for (int k = 0; k < countRight; k++)
            {
                rightJellies = Instantiate(enemies[7], new Vector3(transform.position.x + 5f - (k * displacement), transform.position.y, 0), Quaternion.identity) as GameObject;
                rightJellies.transform.SetParent(GameObject.Find("Enemies").transform);
            }
            yield return new WaitForSeconds(0.5f);
            if (i < 13)
            {
                countLeft--;
                countRight++;
            }
            else
            {
                countLeft++;
                countRight--;
            }
        }
        
        yield return new WaitForSeconds(2);

        spawnPos = -2.5f;
        //Start spawning shieldy jellies with normal jellies
        //two norm reds with one shielded blue
        redJelly1 = Instantiate(enemies[0], new Vector3(transform.position.x - 0.45f - spawnPos, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly1.transform.SetParent(GameObject.Find("Enemies").transform);
        redJelly2 = Instantiate(enemies[0], new Vector3(transform.position.x + 0.45f - spawnPos, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly2.transform.SetParent(GameObject.Find("Enemies").transform);
        iceJelly = Instantiate(enemies[3], new Vector3(transform.position.x - spawnPos, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);

        yield return new WaitForSeconds(3);

        spawnPos = 2.5f;
        redJelly1 = Instantiate(enemies[1], new Vector3(transform.position.x - 0.45f - spawnPos, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly1.transform.SetParent(GameObject.Find("Enemies").transform);
        redJelly2 = Instantiate(enemies[1], new Vector3(transform.position.x + 0.45f - spawnPos, transform.position.y + 0.25f, 0), Quaternion.identity) as GameObject;
        redJelly2.transform.SetParent(GameObject.Find("Enemies").transform);
        iceJelly = Instantiate(enemies[2], new Vector3(transform.position.x - spawnPos, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);

        yield return new WaitForSeconds(5);

        spawnPos = 1.5f;
        iceJelly = Instantiate(enemies[2], new Vector3(transform.position.x - spawnPos, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);

        yield return new WaitForSeconds(2.5f);

        spawnPos = -2;
        iceJelly = Instantiate(enemies[3], new Vector3(transform.position.x - spawnPos, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);

        yield return new WaitForSeconds(2.5f);

        spawnPos = 3;
        iceJelly = Instantiate(enemies[2], new Vector3(transform.position.x - spawnPos, transform.position.y, 0), Quaternion.identity) as GameObject;
        iceJelly.transform.SetParent(GameObject.Find("Enemies").transform);

        yield return new WaitForSeconds(10f);
        
        //WARNING BOSS INCOMING
        //change music

        //Spawn boss
        iceJelly = Instantiate(bosses[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            //Yield if the player dies
            //reset to the beginning/checkpoint

            yield return null;
    }
    */
}
