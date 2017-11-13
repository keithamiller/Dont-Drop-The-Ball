using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    AudioSource audio;

    public AudioClip coinPickupSound;
    public AudioClip playerDeathSound;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayCoinSound()
    {
       
        audio.PlayOneShot(coinPickupSound);
    }

    public void PlayDeathSound()
    {
        audio.PlayOneShot(playerDeathSound);
    }
    
}
