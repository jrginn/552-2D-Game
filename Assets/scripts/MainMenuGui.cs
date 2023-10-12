using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GotoNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
