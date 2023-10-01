using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{


    public void CloseApp()
    {
        Application.Quit();
    }

    public void Loadscene(string sceneString)
    {
        SceneManager.LoadScene(sceneString);
    }
    
    
    
}
