using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    private static MyGameManager _instance;

    public static MyGameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameObject().AddComponent<MyGameManager>();
            return _instance;
        }
    }

    public Text textOut;
    public InputField textIn;

    private CommandParser commandParser;
    private Map map;
	private Player player;
    private PickUp pickup;
    private Quest quest;


    //List for logging previous actions
    static List<string> actionLog = new List<string>();


    void Awake()
    {
        map = new Map();
        commandParser = new CommandParser();
        textIn = GameObject.Find("InputField").GetComponent<InputField>();
        textOut = GameObject.Find("Text-out").GetComponent<Text>();
        player = new Player();
    }

    private void Start()
    {
        ShowMessage("Loading game map...");
        ChangeLocation(map.GetStartLocation());
        
        
    }

    public void ProcessInput(string userText)
    {
        // add user text to output history
        string userTextColored =  "\n >" + Util.ColorText(userText, "red");
        ShowMessage(userTextColored);

        // get command Type from text
        CommandAndOtherWords commandNounPair = commandParser.Parse(userText);

        Util.Command command = commandNounPair.command;

        switch (commandNounPair.numWords)
        {
            case 1:
                // process that command
                ProcessSingleWordUserCommand(command);
                break;

            case 2:
            default:
                // process that command
                ProcessMultiWordUserCommand(commandNounPair);
                break;
        }

        // set input field with Focus - ready for next user input
        textIn.Select();
        textIn.ActivateInputField();

        player.OnPlayerMoved();
        
    }

    private void ProcessMultiWordUserCommand(CommandAndOtherWords commandNounPair)
    {
        Util.Command command = commandNounPair.command;
        Util.Noun noun = commandNounPair.noun;
        
        
        string message = "";
        switch (command)
        {
            case Util.Command.Pick:
                switch (noun)
                {
                    case Util.Noun.Up:
                        message = "noting to pick up";
                        if (player.GetLocation().pickupables.Count == 1)
                        {
                            PickUp item = player.GetLocation().pickupables[0];
                            message = "You picked up: " + item.name + " (" + item.description + ")";   
                            player.addItem(item);
                            player.GetLocation().pickupables = new List<PickUp>();
                            
                        }
        
                        break;
                    default:
                        message = Util.Message(Util.Type.Unknown);
                        break;
                }
                break;
                default:
                message = Util.Message(Util.Type.Unknown);
                break;
        }

        ShowMessage(message);
        }

    private void ProcessSingleWordUserCommand(Util.Command c)
    {
        string message;
        switch(c)
        {
            case Util.Command.Quit:
                message = "user wants to QUIT";
                break;
            case Util.Command.Look:
                message = "You look around... \n " + player.GetLocation().GetLookDesc();
                break;
            case Util.Command.Help:
                message = "HELP: \n " + player.GetLocation().GetFullHelp();               
                break;
            case Util.Command.Talk:
                
                if (player.GetLocation().quests.Count == 1)
                { 
                    Quest quest = player.GetLocation().quests[0];
                    message = player.GetLocation().GetTalk() + " \n New Quest added!  \n" + quest.name + " (" + quest.description + ")";           
                    player.addQuest(quest);
                    player.GetLocation().quests = new List<Quest>();
                 

                }
                else
                {
                    message = "There is no one to talk to here";
                }
                break;
            case Util.Command.Journal:
                message = "Journal: \n " ;
                if(player.quests.Count == 1){

                foreach (Quest quest in player.quests)
                    {
                        message = "Quests: \n" + "Quest Name: " + quest.name + "\n " + "Description: " +quest.description;
                    }
                }
                else
                {
                    message = "You have no active quests";
                } 
                break;
            case Util.Command.Backpack:
                message = "You look into your backpack: \n " ;
                if (player.items.Count > 0)
                {
                    foreach (PickUp item in player.items)
                    {
                        message = "Your Items: \n" + item.name + " (" + item.description+ ")\n ";
                    }
                }
                else
                {
                    message = "no items in backpack";
                } 
                break;
            case Util.Command.North:
                if (null != player.GetLocation().exitNorth)
                {
                    message = Util.Message(Util.Type.North);
                    ChangeLocation(player.GetLocation().exitNorth);                    
                }
                else
                {
                    message = "Sorry - there is no exit to the North";
                }
                break;
            case Util.Command.South:
                if (null != player.GetLocation().exitSouth)
                {
                    message = Util.Message(Util.Type.South
                    );
                    ChangeLocation(player.GetLocation().exitSouth);                    
                }
                else
                {
                    message = "Sorry - there is no exit to the South";
                }
                break;
            case Util.Command.East:
                if (null != player.GetLocation().exitEast)
                {
                    message = Util.Message(Util.Type.East
                    );
                    ChangeLocation(player.GetLocation().exitEast);                    
                }
                else
                {
                message = "Sorry - there is no exit to the East";
                }
                break;
            case Util.Command.West:
                if (null != player.GetLocation().exitWest)
                {
                    message = Util.Message(Util.Type.West
                    );
                    ChangeLocation(player.GetLocation().exitWest);                    
                }
                else
                {
                message = "Sorry - there is no exit to the West";
                }
                break;
            case Util.Command.Unknown:
            default:
                message = Util.Message(Util.Type.Unknown);
                break;
        }

        ShowMessage(message);
    }

    private void ChangeLocation(Location newLocation)
    {
        player.SetLocation(newLocation);
        MyGameManager.instance.ShowMessage(player.GetLocation().GetFullDescription());
    }


    public void ShowMessage(string message)
    {
        LogString(message);
        DisplayLoggedText();

    }//end showMessage


    //method to log actions of the user
    public void LogString(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");

    }//end LogString method

    //method to display the previous actions
    public void DisplayLoggedText()
    {
        //add user input to an array
        string logAsText = string.Join("\n", actionLog.ToArray());
        textOut.text = logAsText;
    }//end displayLoggedText method


}
