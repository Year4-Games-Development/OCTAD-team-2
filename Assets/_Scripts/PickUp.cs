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

    /*
    void selectType (Type newType)
    {
        type = newType;
    }
    */
}
