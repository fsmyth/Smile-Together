using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public PetStatus petStatus;
    long dateLong;

    void Start()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;
         //Grab the old time from the player prefs as a long
        if(PlayerPrefs.HasKey("savedDate")) {
            dateLong = Convert.ToInt64(PlayerPrefs.GetString("savedDate"));
            } else {
                PlayerPrefs.SetString("savedDate", System.DateTime.Now.ToBinary().ToString());
                dateLong = Convert.ToInt64(PlayerPrefs.GetString("savedDate"));
                }
         
        //Convert the old time from binary to a DateTime variable
        DateTime oldDate = DateTime.FromBinary(dateLong);
 
        //Find the difference between the current date and the last stored date.
        double timePassed = (currentDate - oldDate).TotalHours;
        Debug.Log("Time Passed: " + timePassed);
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString("savedDate", System.DateTime.Now.ToBinary().ToString());
        Debug.Log("Saving this date to prefs: " + System.DateTime.Now);

        
        if (timePassed>168) {
            //Reduce Hunger Health & Happiness to 0.
            petStatus.timeDecayPet("hunger", 100);
            petStatus.timeDecayPet("health", 100);
            petStatus.timeDecayPet("fun", 100);
            petStatus.timeRechargePet(1);
        } else if (timePassed>72) {
            //Reduce Hunger Health & Happiness by 75.
            petStatus.timeDecayPet("hunger", 75);
            petStatus.timeDecayPet("health", 75);
            petStatus.timeDecayPet("fun", 75);
            petStatus.timeRechargePet(2);
        } else if (timePassed>48) {
            //Reduce Hunger by 75, Health & Happiness by 30.
            petStatus.timeDecayPet("hunger", 75);
            petStatus.timeDecayPet("health", 30);
            petStatus.timeDecayPet("fun", 30);
            petStatus.timeRechargePet(3);
        } else if (timePassed>24) {
            // Reduce Hunger by 50, & Happiness by 20.
            petStatus.timeDecayPet("hunger", 50);
            petStatus.timeDecayPet("fun", 20);
                int hunger = petStatus.getStatus("hunger");
                int health = petStatus.getStatus("health");
                if (hunger<30) petStatus.timeDecayPet("fun", 25);
                if (health<30) petStatus.timeDecayPet("fun", 50);
            petStatus.timeRechargePet(4);
        } else if (timePassed>12) {
            //Reduce hunger by 30
            petStatus.timeDecayPet("hunger", 30);
            petStatus.timeDecayPet("fun", 15);
                int hunger = petStatus.getStatus("hunger");
                int health = petStatus.getStatus("health");
                if (hunger<30) petStatus.timeDecayPet("fun", 20);
                if (health<30) petStatus.timeDecayPet("fun", 35);
            petStatus.timeRechargePet(5);
        } else if (timePassed>3) {
            //Reduce hunger by 25
            petStatus.timeDecayPet("hunger", 25);
            petStatus.timeDecayPet("fun", 15);
                int hunger = petStatus.getStatus("hunger");
                int health = petStatus.getStatus("health");
                if (hunger<30) petStatus.timeDecayPet("fun", 15);
                if (health<30) petStatus.timeDecayPet("fun", 25);
            petStatus.timeRechargePet(6);
        } else if (timePassed>1) {
            //Reduce hunger by 10
            petStatus.timeDecayPet("hunger", 10);
            petStatus.timeDecayPet("fun", 10);
                int hunger = petStatus.getStatus("hunger");
                int health = petStatus.getStatus("health");
                if (hunger<30) petStatus.timeDecayPet("fun", 10);
                if (health<30) petStatus.timeDecayPet("fun", 20);
            petStatus.timeRechargePet(7);
        } else {
            //Reduce hunger by 1
            petStatus.timeDecayPet("hunger", 1);
            petStatus.timeDecayPet("fun", 1);
                int hunger = petStatus.getStatus("hunger");
                int health = petStatus.getStatus("health");
                if (hunger<30) petStatus.timeDecayPet("fun", 5);
                if (health<30) petStatus.timeDecayPet("fun", 10);
            petStatus.timeRechargePet(8);
        }
    }
 
 }
