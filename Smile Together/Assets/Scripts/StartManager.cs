using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    
     public static StartManager startManager;
    string scene;
    public Animator bodyAnim, headAnim, tailAnim, lightAnim;
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        if(scene == "Start_Scene") {
        bodyAnim.Play("Sleeping");
        headAnim.Play("SleepingHead");
        tailAnim.Play("SleepingTail");
        } else if(scene == "Main_Scene") {
        bodyAnim.Play("WakeUp");
        headAnim.Play("WakeUpHead");
        tailAnim.Play("WakeUpTail");
        lightAnim.Play("LightsOn");
        }
    }
    void OnMouseDown()
    {
        if(scene == "Start_Scene") {
        SceneManager.LoadScene("Main_Scene");
        }
    }
    
}
