using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{

    public AudioSource sfxPlayer;
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioClip sfx3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playPowerUpSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
