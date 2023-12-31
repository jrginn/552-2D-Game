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
    public AudioClip pumpkinThudV2;
    // Start is called before the first frame update

    public GameObject SFX;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        SFX = GameObject.FindGameObjectWithTag("SoundManager");
        SFX.GetComponent<SoundManager>().playMenuSelect();

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
        audioSource.PlayOneShot(pumpkinThudV2);
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
