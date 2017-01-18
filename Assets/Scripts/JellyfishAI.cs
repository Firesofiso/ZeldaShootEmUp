using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyScript))]
[RequireComponent(typeof(Animator))]
public class JellyfishAI : MonoBehaviour {

    public float shockDelay;

    private int baseShockDmg;
    private Animator anim;
    private EnemyScript enemy;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyScript>();
        baseShockDmg = enemy.dmg;
        StartCoroutine(JellyShockTiming());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator JellyShockTiming()
    {
        while (true)
        {
            anim.SetTrigger("Shock");
            yield return new WaitForSeconds(Random.Range(shockDelay - 1, shockDelay + 1));
        }
    }

    public void ToggleShockDamage()
    {
        Debug.Log("Enemy Damage: " + enemy.dmg + " Base Damage: " + baseShockDmg);
        if (enemy.dmg == baseShockDmg)
        {
            enemy.dmg *= 2;
        } else
        {
            enemy.dmg /= 2;
        }
        
    }
}
