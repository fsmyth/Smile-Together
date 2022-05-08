using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCanvas : MonoBehaviour
{

    public GameObject quitScreen;
    bool quitOpen = false;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !quitOpen)
        {
            quitScreen.SetActive(true);
            quitOpen=true;
        } else if (Input.GetKeyDown(KeyCode.Escape) && quitOpen)
        { 
            quitOpen = false;
            quitScreen.SetActive(false);
        }

    }
    public void QuitButton()
    {
        Debug.Log("Quitting!");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ReturnButton()
    {
            quitOpen = false;
            quitScreen.SetActive(false);
    }
}
