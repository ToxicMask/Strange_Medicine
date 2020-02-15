using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ITEM_TYPE
{
    SCISSOR,
    SAW,
    HAMMER,
    BRAIN,
    HEART,
    LEG,
    COUNT,
    EMPTY = -1,
}


//[System.Serializable]
public class Item 
{

    public string[] string_names = new string[] { "Scissor", "Saw", "Hammer", "Brain", "Heart", "Leg" };

    public ITEM_TYPE item_id = ITEM_TYPE.EMPTY;
    public string name = "";

    public Item(ITEM_TYPE id)
    {
        
        this.item_id = id;

        if (id != ITEM_TYPE.EMPTY)
        { this.name = string_names[(int)id]; }
        else
        { this.name = "Empty Hand"; }
    }
}