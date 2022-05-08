using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;

//A single message from the game chat
public class Chat {
    public string Text;
    public Text TextObject;
    public ChatType ChatType;

}

//Differentiate between Player messages and pet messages.
public enum ChatType {
    Player, Pet
}

public class BotDialog: Dialog
{

    int dFun;
    int dHunger;
    int dHealth;
    int dEnergy;

/////////////////////////// Greeting

    [Expression("your name ?")]
    [Expression("you called ?")]
    [Expression("who are you ?")]
    public void MyName(Context context, Result result)
    {
        result.SendResponse("I'm Sol!");
    }

    [Expression("Hello")]
    [Expression("Hi")]
    public void Hello(Context context, Result result)
    {
        result.SendResponse("Hi! How are you?");
    }

    [Expression("Sol")]
    [Expression("sol")]
    public void Sol(Context context, Result result)
    {
        result.SendResponse("That's me!");
    }

    [Expression("How are you?")]
    [Expression("How're you?")]
    [Expression("Are you okay?")]
    [Expression("tell me about you feeling yourself")]
    public void Feeling(Context context, Result result)
    {
        dFun = Chatbot.getFun();
        dHunger = Chatbot.getHunger();
        dHealth = Chatbot.getHealth();
        dEnergy = Chatbot.getEnergy();
        if (dHealth<50) {result.SendResponse("I think I'm sick...");}
        else if (dHealth<80) {result.SendResponse("I don't feel so good");}
        else if (dHunger<50) {result.SendResponse("I'm starving!");}
        else if (dHunger<80) {result.SendResponse("I'm a little hungry...");}
        else if (dEnergy<50) {result.SendResponse("I'm exhausted!");}
        else if (dEnergy<80) {result.SendResponse("I'm a little tired...");}
        else if (dFun<80) { result.SendResponse("I'm bored!"); }
        else {
            result.SendResponse("I'm okay!");
        }
        
    }

/////////////////////////// Hunger

    [Expression("Are you hungry?")]
    public void Hunger(Context context, Result result)
    {
        dHunger = Chatbot.getHunger();
        if (dHunger<25) {result.SendResponse("I'm starving!");}
        else if (dHunger<50) {result.SendResponse("I'm a little hungry...");}
        else result.SendResponse("I'm okay!");   
    }

    [Expression("What food do you like ?")]
    [Expression("food like ?")]
    [Expression("enjoy food ?")]
    [Expression("What do you like to eat ?")]
    [Expression("tell me about food hunger eat")]
    public void FavouriteFood(Context context, Result result)
    {
        result.SendResponse("I love Fish!");
        
    }
    [Expression("Meat")]
    [Expression("Cheese")]
    public void DislikedFood(Context context, Result result)
    {
        result.SendResponse("Blegh!");
        
    }

/////////////////////////// Fun

    [Expression("Are you bored?")]
    public void Boredom(Context context, Result result)
    {
        if (dFun<25) {result.SendResponse("I'm so bored...");}
        else if (dFun<50) {result.SendResponse("...A little!");}
        else result.SendResponse("Not at all!");
    }

    [Expression("What can we do")]
    [Expression("What can I do")]
    [Expression("What do you do")]
    public void SuggestGame(Context context, Result result)
    {
        dFun = Chatbot.getFun();
        dHunger = Chatbot.getHunger();
        dHealth = Chatbot.getHealth();
        dEnergy = Chatbot.getEnergy();
        if (dHunger<50) {result.SendResponse("Feed Me!");}
        else if (dHealth<40) {result.SendResponse("I'm sick... Can you help?");}
        else if (dEnergy<25) {result.SendResponse("I'm exhausted! Let's play later");}
        else {
            result.SendResponse("Let's play a game!");
        }
    }

    [Expression("Do you want to play a game?")]
    [Expression("Would you like to play a game?")]
    public void PlayAGame(Context context, Result result)
    {
        dEnergy = Chatbot.getEnergy();
        dHunger = Chatbot.getHunger();
        if (dEnergy<30) {result.SendResponse("Maybe later, I'm tired...");}
        else if (dHunger<40) {result.SendResponse("I'm too hungry...");}
        result.SendResponse("Yeah! Let's play!");
        
    }

    [Expression("What game can we play")]
    [Expression("tell me about game")]
    [Expression("What games")]
    public void WhatGame(Context context, Result result)
    {
        result.SendResponse("We can catch mice!");
    }

    [Expression("high score")]
    [Expression("highscore")]
    [Expression("score")]
    public void WhatScore(Context context, Result result) {
        int hs = PlayerPrefs.GetInt("highScore");
        result.SendResponse("The high score is "+hs);
    }

/////////////////////////// Health

    [Expression("How can I help")]
    [Expression("help get better")]
    [Expression("what's wrong")]
    [Expression("recover")]
    [Expression("tell me about health sick medicine")]
    public void Recovery(Context context, Result result)
    {
        result.SendResponse("I'm Sick!");
    }


/////////////////////////// Misc

    [Expression("I'm good")]
    [Expression("okay")]
    [Expression("Ok")]
    [Expression("alright")]
    [Expression("great")]
    [Expression("fantastic")]
    public void PositiveResponse(Context context, Result result)
    {
        result.SendResponse("That's good..."); 
    }

    [Expression("I love")]
    [Expression("cute")]
    public void LoveResponse(Context context, Result result)
    {
        result.SendResponse("Aww!!!"); 
    }

    [Expression("I'm leaving")]
    [Expression("bye")]
    [Expression("see you later")]
    [Expression("seeya")]
    [Expression("goodbye")]
    public void ByeResponse(Context context, Result result)
    {
        result.SendResponse("Take care!"); 
    }
    

    [Expression("not so good")]
    [Expression("bad")]
    [Expression("awful")]
    [Expression("hate")]
    public void NegativeResponse(Context context, Result result)
    {
        result.SendResponse("I'm sorry to hear that");   
    }

    [Expression("me too")]
    [Expression("same")]
    [Expression("I'm the same")]
    [Expression("also")]
    [Expression("as well")]
    public void SameResponse(Context context, Result result)
    {
        result.SendResponse("Wow! We have so much in common");   
    }

    [Expression("what's it like being a pet?")]
    [Expression("don't exist")]
    [Expression("virtual pet")]
    public void SelfAware(Context context, Result result)
    {
        result.SendResponse("Hmm, I may only be a virtual pet, but I'm happy!");   
    }

////////////////////////////// Reset
    [Expression("Delete User")]
    [Expression("Reset All")]
    public void DeleteUser(Context context, Result result)
    {
        result.SendResponse("Ok! What is your name?");   
    }
}


public class Chatbot : MonoBehaviour
{

    OscovaBot MyPet;
    public PetStatus petStatus;

    //List of all chat messages
    List<Chat> Chats = new List<Chat>();

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    //Uses American english, so must use Color instead of Colour & Dialog instead of Dialogue
    public Color PlayerColour, PetColour;
    public static int fun;
    public static int health;
    public static int hunger;
    public static int energy;

        void Start()
        {
            try {
                MyPet = new OscovaBot();
                MyPet.Dialogs.Add(new BotDialog());
                MyPet.Trainer.StartTraining();

                MyPet.MainUser.ResponseReceived += (sender, evt) => {
                    AddChat($" {evt.Response.Text}", ChatType.Pet);
                };
            }
            catch (Exception ex) {
                Debug.LogError(ex);
            }
        }

        void Update()
        {
            
            fun = petStatus.getStatus("fun");
            hunger = petStatus.getStatus("hunger");
            energy = petStatus.getStatus("energy");
            health = petStatus.getStatus("health");
            //Listen for when the enter key is pressed
            if (Input.GetKeyDown(KeyCode.Return))
                {
                    SendChatToPet();
                }
        }

public static int getFun() {
    int newFun = fun;
    return newFun;
}

public static int getHealth() {
    int newHealth = health;
    return newHealth;
}

public static int getHunger() {
    int newHunger = hunger;
    return newHunger;
}

public static int getEnergy() {
    int newEnergy = energy;
    return newEnergy;
}
    public void AddChat(string chatText, ChatType chatType)
    {
        if (Chats.Count >= 1)
        {
            //Remove previous message so only last message is shown.
            Destroy(Chats[0].TextObject.gameObject);
            Chats.Remove(Chats[0]);
        }

        var newChat = new Chat { Text = chatText };
        var newText = Instantiate(textObject, chatPanel.transform);
        newChat.TextObject = newText.GetComponent<Text>();
        newChat.TextObject.text =  chatType == ChatType.Player ? "I don't understand" : chatText;

        Chats.Add(newChat);
    } 
    
    public void SendChatToPet()
    {
        //Retrieve the player's input
        var playerChat = chatBox.text;

        //Check if player's name is saved yet
        bool hasName = petStatus.getHasName();
        if (!hasName) {
            //Set player's name
            petStatus.setName(playerChat);
            AddChat($" {playerChat}", ChatType.Pet);
            chatBox.Select();
            chatBox.text = "";
        } else {

        //Delete user's name
        if (playerChat.Contains("Delete User")) 
            {
                petStatus.delName();
                chatBox.Select();
                chatBox.text = "";
            }

        //Reset entire game
        if(playerChat.Contains("Reset All"))
            {
                petStatus.delAll();
                chatBox.Select();
                chatBox.text = "";
            }
        
            AddChat($" {playerChat}", ChatType.Player);        
            var request = MyPet.MainUser.CreateRequest(playerChat);
            var evaluationResult = MyPet.Evaluate(request);
            evaluationResult.Invoke();
            chatBox.Select();
            chatBox.text = "";
        }
    }
}
