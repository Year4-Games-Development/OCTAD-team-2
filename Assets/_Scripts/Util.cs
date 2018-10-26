using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static readonly Dictionary<string, string> commands;

    static Util()
    {
        commands = new Dictionary<string, string>();
        // TODO: Read a file instead.
        commands.Add("quit", "Quits the game.");
        commands.Add("look", "Look around you.");
        commands.Add("north", "Makes your character move to the north side of your current location.");
        commands.Add("south", "Makes your character move to the south side of your current location.");
        commands.Add("east", "Makes your character move to the east side of your current location.");
        commands.Add("west", "Makes your character move to the west side of your current location.");
        commands.Add("pickup", "Picks up an item.\nUsage: pickup <item name>");
        commands.Add("drop", "Drops an item.\nUsage: drop <item name>");
    }

    public enum Type
	{
		Start,
		Help,
		Unknown,
		North,
		South,
		East,
		West
	}
	
	public enum Command
	{
		Quit,
		Help,
		Look,
		Talk,
		North,
		South,
		East,
		West,
		Pickup,
		Backpack,
		Pick,
		Journal,
		Drop,
		Unknown        
	}
	
	public enum Noun
	{
		Door,
		Key,
		Up,
		Unknown
        
	}

	public static string Message(Type t)
	{
		switch (t)
		{
			case Type.Unknown:
				return "UNKNOWN command - please write something I understand";

			default:
				/*
				 * TODO: Generate some kind of error event ??
				 */
				return "";				
		}

	}


	public static string ColorText(string t, string color)
	{
		return "<color=" + color + ">" + t + "</color>";
	}

    public static string ColorText(string t, Color color)
    {
        return "<color=#" +
            ((int)(color.r * 255f)).ToString("X2") +
            ((int)(color.g * 255f)).ToString("X2") +
            ((int)(color.b * 255f)).ToString("X2") +
            ">" + t + "</color>";
    }
}
