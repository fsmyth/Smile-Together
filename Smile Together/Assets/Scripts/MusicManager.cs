using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    #pragma warning disable 649
     [SerializeField]
     private AudioClip menuMusic;
     [SerializeField]
     private AudioClip gameMusic;
     [SerializeField]
     private AudioSource source;
    #pragma warning restore 649

    string scene;
     public static MusicManager musicManager;
     public string nowPlaying;
     //Starts the music when it's loaded.
     void Awake(){
         if (musicManager == null){
             musicManager = this;
             DontDestroyOnLoad(gameObject);
        } else if(musicManager != this) {
             Destroy(gameObject);
     }
    }
    //Starts with the menu music.
    void Start() {
        MenuMusic();
    }

    //If in the menu, play the menu music.
    public static void MenuMusic() {
        if (musicManager != null && musicManager.nowPlaying !="Menu") {
            musicManager.source.Stop();
            musicManager.source.clip = musicManager.menuMusic;
            musicManager.source.Play();
            musicManager.nowPlaying = "Menu";
        }
    }
    public static void GameMusic() {
        if (musicManager != null && musicManager.nowPlaying !="Game") {
            musicManager.source.Stop();
            musicManager.source.clip = musicManager.gameMusic;
            musicManager.source.Play();
            musicManager.nowPlaying = "Game";
        }
    }

    //If the player presses M, mutes the music.
    void Update() {

        scene = SceneManager.GetActiveScene().name;

        if(scene =="Play_Scene"){
            GameMusic();
        }

        if(scene!="Play_Scene"){
            MenuMusic();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl)){
            if (musicManager.source.mute) {
                musicManager.source.mute = false;
            } else musicManager.source.mute = true;
    }

    }
}
