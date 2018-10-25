﻿using System;
using System.Collections;
using System.Collections.Generic;


public class Player
{
    // float hp;
    // float maxHp;
    float oxygenLevel;

    /*
     * can infer from oxygen level ...
    bool isDead;
     */

    List<PickUp> items;
    //    List<int> quests;
    float amountOfMoney;
    Location currentLocation;

    public Player()
    {
        oxygenLevel = 1.0f;

        //	    hp = 10;
        //	    maxHp = 10;
        //      isDead = false;
    }
    
    void addItem(PickUp item)
    {
        items.Add(item);
    }

    void removeItem(PickUp item)
    {
        items.Remove(item);
    }

    /*
    void takeDamages(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            isDead = true;
    }

    void recoverHp(float heal)
    {
        hp += heal;
        if (hp > maxHp)
            hp = maxHp;
    }
    
    void addQuest(int questId)
    {
        quests.Add(questId);
    }

    void removeQuest(int questId)
    {
        quests.Remove(questId);
    }

    void earnMoney(float money)
    {
        amountOfMoney += money;
    }

    void looseMoney(float money)
    {
        amountOfMoney -= money;
    }
    */

    public void SetLocation(Location location)
    {
        currentLocation = location;
    }

    public Location GetLocation()
    {
        return currentLocation;
    }

    public void OnPlayerMoved()
    {
        currentLocation.firstVisit = false;
        if (currentLocation.name == "In Ship") // FIXME: Hardcoded string.
        {
            if (oxygenLevel != 1.0f)
            {
                oxygenLevel = 1.0f;
                MyGameManager.instance.ShowMessage("Oxygen refilled.");
            }
        }
        else
        {
            oxygenLevel -= .01f;
            MyGameManager.instance.ShowMessage("Current Oxygen Level: " + (oxygenLevel * 100) + "%");
        }
        
    }

    // Function when you find healthbox. It increases your oxygen level by
    public float HealthBoxFound() {
        oxygenLevel += .2f;

        if(oxygenLevel > 1.0f) {

            oxygenLevel = 1.0f;
        }

        return oxygenLevel;
    }

    public bool IsDead()
    {
        return oxygenLevel <= .0f;
    }
}
