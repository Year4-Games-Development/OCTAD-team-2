using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
	private Location startInShip;

	private List<Location> locations;
	
	public Location GetStartLocation()
	{
		return startInShip;
	}

	
	public Map() {
		startInShip =  new Location();
		Location outsideShip = new Location();
		Location cave = new Location();
		Location forest = new Location(); 
		Location town = new Location();
		Location tavern = new Location();
		Location scrapyard = new Location();
		Location market = new Location();

		locations = new List<Location>();
		locations.Add(startInShip);
		locations.Add(outsideShip);
		locations.Add(cave);
		locations.Add(forest);
		locations.Add(town);
		locations.Add(tavern);
		locations.Add(scrapyard);
		locations.Add(market);
		

		startInShip.name = "In Ship";
		startInShip.exitSouth = outsideShip;
		startInShip.pickupables = new List<PickUp>();
		startInShip.descriptions = new string[]
		{
			"You wake up in the spaceship to the feeling of your eyes being stung by extremely bright lights. \n " +
			"In the centre of the ship, you see a body lying on a table with bright lights trained down on it\n" +
			"\n" +
			"If somehow i could find out what's wrong with this ship. \n"+
			"There is no way i am getting off this planet right now. \n" +
			" "
		};
		startInShip.look = new string[]
		{
			"You see a (Inventory object) against the wall to the right of you. \n",
			"There is a door to the South.\n",
			"The ship seems damaged,\n"
			
			
		};
		startInShip.help = new string[]
		{
			"Pick up the (inventory object) it might be useful",
			"Your spaceship seem to be broken",
			"You need to leave the ship"
			
		};	

		outsideShip.name = "Outside Ship";
		outsideShip.exitNorth = startInShip;
		outsideShip.exitSouth = cave;
		outsideShip.exitWest = forest;
		outsideShip.exitEast = town;
		outsideShip.pickupables = new List<PickUp>();
		outsideShip.descriptions = new string[]
		{
			"You are in a dark field. \n " +
			"Behind you there is a door leading back to the spaceship.\n" +
			" "
		};
		outsideShip.look = new string[]
		{
			"To the west, you see a forest.",
			"To the east there is a small town.",
			"To the south, there appears to be a dark cave.",
			"There seems to be a town to the east."
		};
		outsideShip.help = new string[]
		{
			"Try to to look around for places you can go.",
			"Try to get some items to fix your ship"
			
		};	
	
	
		cave.name = "Cave";
		cave.exitNorth = outsideShip;
		cave.pickupables = new List<PickUp>();
		cave.descriptions = new string[]
		{
			"You are in a really dark cave with a significantly lower temperature. \n " +
			"There is a strong stench of dampness in the air. \n " +
			""
		};
		cave.look = new string[]
		{
			"You can see a really dim light coming from the very back of the cave. \n",
			"There is a lantern close to the entrance of the cave. (Possible inventory object).",
			"To the south is your crashed spaceship."
		};
		cave.help = new string[]
		{
			"You might need some source of light to enter the cave",
			"It seems too dark to go into the cave."
		};

		forest.name = "Forest";
		forest.exitEast = outsideShip;
		forest.pickupables = new List<PickUp>();
		forest.descriptions = new string[]
		{
			"You are in a forest surrounded by dense fog and tall trees. \n " +
			"The forest floor is strewn with dead animal carcases. \n " +
			"You can hear rumblings of bushes in the forest in the distance. \n " +
			" "
		};
		forest.look = new string[]
		{
		"To the east is your crashed spaceship.",
		"To the east is your crashed spaceship."
		};
		forest.help = new string[]
		{
			"Its dangerous there.",
			"You might need some weapon to enter the forest"
			
		};	

		town.name = "Town";
		town.exitWest = outsideShip;
		town.exitNorth = market;
		town.exitSouth = scrapyard;
		town.exitEast = tavern;
		town.pickupables = new List<PickUp>();
		town.descriptions = new string[]
		{
			"You have entered the town, it’s a small busy town, aliens don't seem to care about you.\n " +
			" "
		};
		town.look = new string[]
		{
			"There is a scrap yard to the south, you can find some items to repair your ship.",
			"To the north you see a small market maybe you can purchase items.",
			"To the east is your crashed spaceship.",
			"To the east there is a small old tavern you might get some help there."
		};
		town.help = new string[]
		{
			"You can buy items in the market",
			"You can find parts for your ship in the scrapyard",
			"You can talk to someone in the tavern"	
		};	

		market.name = "Market";
		market.exitSouth = town;
		market.pickupables = new List<PickUp>();
		market.descriptions = new string[]
		{
			"You enter the market and you notice few stalls with bright dimming lights. \n " +
			"People seem to be friendly there \n "+
			"You'll be able to trade items in the market. \n " +
			" "
		};
		market.look = new string[]
		{
			"You see four stalls"
		};
		market.help = new string[]
		{
			"Try to talk to the sellers",
			"You can guy items here in market",
			"You can talk to someone in the tavern"	
		};	

		tavern.name = "Tavern";
		tavern.exitWest = town;
		tavern.pickupables = new List<PickUp>();
		tavern.descriptions = new string[]
		{
			"You entered the tavern, its nice and warm here. \n " +
			"There is a nice music playing in the background and it feels cozy. \n " +
			" "
		};
		tavern.look = new string[]
		{
			"There is an old man sitting at the bar looking at you, looks like he wants to talk to you.",
			"You see an old boom box playing in the corner"
		};
		tavern.help = new string[]
		{
			"Try to talk to someone",
			"Maybe you can help this at the bar",
			"Maybe the old man can help you "	
		};	

		scrapyard.name = "Scrapyard";
		scrapyard.exitNorth = town;
		scrapyard.pickupables = new List<PickUp>();
		scrapyard.descriptions = new string[]
		{
			"You walked to the scrapyard." +
			" "
		};
		scrapyard.help = new string[]
		{
			"You see extremely large piles of broken cars",
			"You can see lots of junk",
			"You see town  behind you"
		};	
		scrapyard.help = new string[]
		{
			"Look for the parts to fix your ship",
			"Maybe you can find useful parts to fix your ship."
		};	
		
		
	}



}
