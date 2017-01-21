using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkAudioHandler : MonoBehaviour {

    //Weapons
    public AudioClip normalLasersClip;


    //Linkstuff
    public AudioClip hurtClip;
    public AudioClip pickUpRupeeClip;
    public AudioClip pickUpHeartClip;

    //Audio Sources
    [HideInInspector]
    public AudioSource normalLasersAudio;
    [HideInInspector]
    public AudioSource hurtAudio;
    [HideInInspector]
    public AudioSource pickUpRupeeAudio;
    [HideInInspector]
    public AudioSource pickUpHeartAudio;

    AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, int priority, float vol, float pitch)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.priority = priority;
        newAudio.volume = vol;
        newAudio.pitch = pitch;

        return newAudio;
    }

    private void Awake()
    {
        normalLasersAudio = AddAudio(normalLasersClip, false, false, 128, Random.Range(0.5f, 1f), 2);
        hurtAudio = AddAudio(hurtClip, false, false, 128, Random.Range(0.5f, 1f), 1);
        pickUpRupeeAudio = AddAudio(pickUpRupeeClip, false, false, 128, Random.Range(0.5f, 1f), 1);
        pickUpHeartAudio = AddAudio(pickUpHeartClip, false, false, 128, Random.Range(0.5f, 1f), 1);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
