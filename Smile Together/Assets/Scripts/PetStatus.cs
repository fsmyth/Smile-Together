using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PetStatus : MonoBehaviour
{
    public Text FunLog;
    public Text Intro;
    public Animator textAnim;
    public Text HungerLog;
    public Text HealthLog;
    public Text EnergyLog;
    public int fun;
    public int hunger;
    public int health;
    public int energy;
    public bool hasName;
    public string prefFood = "Fish"; 
    
    void Start()
    {
        if(SceneManager.GetActiveScene().name =="Main_Scene"){
            if(PlayerPrefs.HasKey("username")) {
                hasName = true;
                Intro.text = "welcome back, " + PlayerPrefs.GetString("username");
                } else {
                    hasName = false;
                    Intro.text = "I'm Sol, what's your name?";
                    }
            }   

        
        if(PlayerPrefs.HasKey("petFun")) {
            fun = PlayerPrefs.GetInt("petFun");
            } else {
                PlayerPrefs.SetInt("petFun", 50);
                fun = PlayerPrefs.GetInt("petFun"); }
                
        if(PlayerPrefs.HasKey("petHunger")) {
            hunger = PlayerPrefs.GetInt("petHunger");
            } else {
                PlayerPrefs.SetInt("petHunger", 50);
                hunger = PlayerPrefs.GetInt("petHunger"); }
                
        if(PlayerPrefs.HasKey("petHealth")) {
            health = PlayerPrefs.GetInt("petHealth");
            } else {
                PlayerPrefs.SetInt("petHealth", 50);
                health = PlayerPrefs.GetInt("petHealth"); }
                
        if(PlayerPrefs.HasKey("petEnergy")) {
            energy = PlayerPrefs.GetInt("petEnergy");
            } else {
                PlayerPrefs.SetInt("petEnergy", 50);
                energy = PlayerPrefs.GetInt("petFun"); }
    
    
        //Stat tracking for Dev
        // HungerLog.text = "Hunger: " + hunger;
        // HealthLog.text = "Health: " + health;
        // FunLog.text = "Fun: " + fun;
        // EnergyLog.text = "Energy: " + energy;
    }

    public int getStatus(string status) {
        if (status=="fun") {
            return(fun);
        } else if (status=="hunger") {
            return(hunger);
        } else if (status=="health") {
            return(health);
        } else if (status=="energy") {
            return(energy);
        } else {return(100);}
    }

    public bool getHasName() {
        // Debug.Log("Do you have a name yet?");
        return(hasName);
    }

    public string getName() {
        string name = PlayerPrefs.GetString("username");
        return name;
    }

    public void setName(string newUsername) {
        PlayerPrefs.SetString("username", newUsername);
        hasName= true;
        Intro.text = "hi";
        textAnim.Play("ChatTextFade");
    }

    public void delName() {
        PlayerPrefs.DeleteKey("username");
        hasName = false;
    }

    public void delAll() {
        PlayerPrefs.DeleteAll();
        hasName = false;
        hunger = 50;
        fun = 50;
        health = 50;
        energy = 50;
        //Stat tracking for Dev
        // HungerLog.text = "Hunger: " + hunger;
        // HealthLog.text = "Health: " + health;
        // FunLog.text = "Fun: " + fun;
        // EnergyLog.text = "Energy: " + energy;
    }

//////////////////////////////// Feeding Pet
    public void feedPet(string food) {
        hunger = PlayerPrefs.GetInt("petHunger");
        health = PlayerPrefs.GetInt("petHealth");
        if (food == prefFood && hunger<100){
            hunger = hunger+25;
            PlayerPrefs.SetInt("petHunger", hunger);
        } else if(health>0) {
            health = health-20;
            PlayerPrefs.SetInt("petHealth", health);    
        }
        HungerLog.text = "Hunger: " + hunger;
        HealthLog.text = "Health: " + health;
    }

///////////////////////////////// Caring for Pet
    public void givePet(string item) {
        fun = PlayerPrefs.GetInt("petFun");
        energy = PlayerPrefs.GetInt("petEnergy");
        health = PlayerPrefs.GetInt("petHealth");

        if (item == "Meds" && health<=50){
            health = health+25;
            PlayerPrefs.SetInt("petHealth", health);
        } else if(item == "Meds") {

            if(fun>0) {
            fun = fun-20;
            }

            if(energy>0) {
                energy = energy-15;
            }

            PlayerPrefs.SetInt("petFun", fun);    
            PlayerPrefs.SetInt("petEnergy", energy);    
        } else if(item == "Comb" && health>50) {

            if (fun<100) {
                fun = fun+10;
            }

            if (health<100) {
                health = health+10;
            }

            PlayerPrefs.SetInt("petFun", fun);    
            PlayerPrefs.SetInt("petHealth", health);    
        }
        
        HealthLog.text = "Health: " + health;
        EnergyLog.text = "Energy: " + energy;
        FunLog.text = "Fun: " + fun;
        // Debug.Log("Gave pet "+item+". Status: Health: "+health+". Fun: "+fun+". Energy: "+energy);
    }

//When time passes outside the game, this is called by the Time script. Pass in the stat and the amount to reduce it by 
    public void timeDecayPet(string stat, int change) {
        fun = PlayerPrefs.GetInt("petFun");
        hunger = PlayerPrefs.GetInt("petHunger");
        health = PlayerPrefs.GetInt("petHealth");
        if (stat=="hunger") {

            if(hunger>0) {
                hunger = hunger-change;
                if (hunger <=0) hunger=0;
            }

            PlayerPrefs.SetInt("petHunger", hunger);
            HungerLog.text = "Hunger: " + hunger;  

        } else if (stat=="health") {

            if(health>0) {
                health = health-change;
                if (health <=0) health=0;
            }

            PlayerPrefs.SetInt("petHealth", health);
            HealthLog.text = "Health: " + health;  

        } else if (stat=="fun") {

            if(fun>0) {
                fun = fun-change;
                if (fun <=0) fun=0;
            }

            PlayerPrefs.SetInt("petFun", fun);  
            FunLog.text = "Fun: " + fun;  

        }
    }

    public void timeRechargePet(int change) {
        energy = PlayerPrefs.GetInt("petEnergy");
        switch (change) {

            case 1: 
                energy = 55;
                break;
            case 2: 
                energy = 75;
                break;
            case 3: 
                energy = 80;
                break;
            case 4: 
                energy = 100;
                break;
            case 5: 
                if (energy<100)
                energy = energy+50;
                break;
            case 6: 
                if (energy<100)
                energy = energy+25;
                break;
            case 7: 
                if (energy<100)
                energy = energy+10;
                break;
            case 8: 
                if (energy<100)
                energy = energy+1;
                break;
        }
        PlayerPrefs.SetInt("petEnergy", energy); 
        EnergyLog.text = "Energy: " + energy; 
    }

    public void SaveAll() {  
        PlayerPrefs.SetInt("petHunger", hunger);
        PlayerPrefs.SetInt("petFun", fun);
        PlayerPrefs.SetInt("petHealth", health);  
        PlayerPrefs.SetInt("petEnergy", energy);
    }

     void OnApplicationQuit()
     {
        //Save the current scores to be remembered when playing next
        SaveAll();
        // print("Saving pet details: Fun: " + fun + " Hunger: " + hunger + " Health: " + health + " Energy: " + energy);
     }
}
