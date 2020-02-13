using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class Item 
{

    public enum ITEM_TYPE
    {
        NEEDLE,
        SAW,
        HAMMER,
        BRAIN,
        HEART,
        LEG,
        COUNT,
        EMPTY = -1,
    } 

    public string[] string_names = new string[] { "Needle", "Saw", "Hammer", "Brain", "Heart", "Leg" };

    public int item_id = -1;
    public string name = "";

    public Item(int id)
    {
        
        this.item_id = id;

        if (id != -1)
        { this.name = string_names[id]; }
        else
        { this.name = "Empty Hand"; }
    }
}