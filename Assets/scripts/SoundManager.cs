using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clearScreen;
    public AudioClip crowCall;
    public AudioClip menuSelection;
    public AudioClip powerUpSound;
    public AudioClip pumpkinThud;
    public AudioClip scarecrowDeath;
    public AudioClip shootSeed;
    public AudioClip shootSeedv2;
    public AudioClip shootSeedv3;
    // Start is called before the first frame update
   
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClearScreen() {
        audioSource.PlayOneShot(clearScreen);
    }

    public void playCrowCall() {
        audioSource.PlayOneShot(crowCall);
    }

    public void playShootSeed() {
        audioSource.PlayOneShot(shootSeedv3);
    }

    public void playScarecrowDeath()
    {
        audioSource.PlayOneShot(scarecrowDeath);
    }
    public void playThud()
    {
        audioSource.PlayOneShot(pumpkinThud);
    }

    public void playMenuSelect()
    {
        audioSource.PlayOneShot(menuSelection);
    }

    public void playPowerUpSound()
    {
        audioSource.PlayOneShot(powerUpSound);
    }
}
