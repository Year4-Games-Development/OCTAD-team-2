using System;

public class PickUp {

/*    
    enum Type
    {
        RecoveryItem,
        Ressource,
        QuestObject
    };
*/

    public int id;
    public string name;
    public string description;

//    Type type;
//    float exchangeValue;

	public PickUp (int id, string name, string description)
	{
	    this.id = id;
	    this.name = name;
	    this.description = description;
	}

    public void Pickup(Player player)
    {
        switch (id) // TODO: Move this.
        {
            case 2: // Instantly use this item and do not add it to inventory.
                player.IncreaseOxygen(.2f); // 20%
                break;
            default:
                player.addItem(this);
                break;
        }
        player.GetLocation().pickupables.Remove(this);
    }

    /*
    void selectType (Type newType)
    {
        type = newType;
    }
    */
}
