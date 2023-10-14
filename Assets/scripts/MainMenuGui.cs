using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuGui : MonoBehaviour
{

    public GameObject SFX;

    // Start is called before the first frame update
    void Start()
    {
        SFX = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GotoNextScene()
    {
        //SFX.GetComponent<SoundManager>().playMenuSelect();
        SceneManager.LoadScene("GameScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
