using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
   public Text comment;
   public Animator textAnim;
   int energy;

   public void FeedButton()
   {
       SceneManager.LoadScene("Feed_Scene");
   }
   
   public void PlayButton()
   {
        energy = PlayerPrefs.GetInt("petEnergy");
        if (energy>25){
            SceneManager.LoadScene("Play_Scene");
        } else {
            comment.text = "I'm too tired!";
            textAnim.Play("ChatTextFade");
        }
   }
   
   public void CareButton()
   {
       SceneManager.LoadScene("Care_Scene");
   }
   
   public void ReturnButton()
   {
       SceneManager.LoadScene("Main_Scene");
   }
}
