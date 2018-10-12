using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Location
{
	public string name; 
	public string shortDesc;


//	public List<Location> exits;

	public Location exitNorth;
	public Location exitSouth;
	public Location exitEast;
	public Location exitWest;
	
	public bool firstVisit = true;
	public List<PickUp> pickupables;
	// public int[] characters; 
	public string[] descriptions;
	
	public string[] help;

	public string[] look;
	int index;
	public string GetName()
	{
		return name;
	}
	
	public string GetLook()
	{	
		//print next item in array	
		if ((index > look.Length -1) || (index < 0))
				Console.Write("something went wrong");
		else if (index == look.Length -1)
			index = 0;

		else
			index++;

		return look[index];
	}
	
	public string GetHelp()
	{	
		//print next item in array	
		if ((index > help.Length -1) || (index < 0))
			Console.Write("something went wrong");
		else if (index == help.Length -1)
			index = 0;

		else
			index++;

		return help[index];       		
	}

	public string GetDescription()
	{
		// first visit show first description
		if (firstVisit)
		{
			return descriptions[0];
		}
		else
		{
			// choose random description
			int randomIndex = Random.Range(0, descriptions.Length);
			return descriptions[randomIndex];
		}
	}

	public string GetExitDescriptions()
	{
		string exitList = "";
		int exitCount = 0;

		if (null != exitNorth)
		{
			exitList += "\n there is an exit to the North";
			exitCount++;
		}

		if (null != exitSouth)
		{
			exitList += "\n there is an exit to the South";
			exitCount++;
		}

		if (null != exitEast)
		{
			exitList += "\n there is an exit to the East";
			exitCount++;
		}

		if (null != exitWest)
		{
			exitList += "\n there is an exit to the West";
			exitCount++;
		}
		return "There are " + exitCount + " exits: " + exitList;
	}

	public string GetFullDescription()
	{
		return GetDescription() + "\n" + GetExitDescriptions();
	}
	
	public string GetFullHelp()
	{
		return GetHelp() + " \n"+  " \n" + GetExitDescriptions();
	}
	public string GetLookDesc()
	{
		return GetLook() + " \n"+  " \n" + GetExitDescriptions();
	}
	
	


}
