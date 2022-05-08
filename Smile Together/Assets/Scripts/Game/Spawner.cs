using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    int fun;
    int energy;
    int highScore;
    public int gameScore;
    public int miceToSpawn;
    public GameObject mouseEnemy;
    public GameObject returnButton;
    public Text scoreText;
    public Text congratText;
    Vector3 mouseSpawnPos;
    void Awake()
    {
        gameScore = 0;
        miceToSpawn = 1;
        InvokeRepeating("MouseSpawn", 2.0f, 3f);
    }

    void MouseSpawn() {
        for (int i = Random.Range(1, miceToSpawn); i>0; i--) {
                mouseSpawnPos = new Vector3 (Random.Range(-4.0f, 4.0f), 21.0f, 18.0f);
                mouseEnemy.transform.position = mouseSpawnPos;
                Instantiate(mouseEnemy); 
        }
        miceToSpawn++;
    }

    public void MouseCatch() 
    {
            gameScore=gameScore+1;
            scoreText.text = ""+gameScore;
    }

    public void GameOver() 
    {
        CancelInvoke();
        miceToSpawn=0;
        fun = PlayerPrefs.GetInt("petFun");
        if (fun<100){
            fun=fun+25;
        }
        energy = PlayerPrefs.GetInt("petEnergy");
        if (energy>0){
            energy=energy-25;
        }
        PlayerPrefs.SetInt("petEnergy", energy);
        PlayerPrefs.SetInt("petFun", fun);
        if(PlayerPrefs.HasKey("highScore")) {

                highScore = PlayerPrefs.GetInt("highScore");

                if (gameScore>highScore){
                    PlayerPrefs.SetInt("highScore", gameScore);
                    congratText.text = "New High Score!";
                } else {
                    congratText.text = "Game Over!";
                }

            } else {
                PlayerPrefs.SetInt("highScore", gameScore);
                congratText.text = "New High Score!";
                }
        returnButton.SetActive(true);
    }
}
