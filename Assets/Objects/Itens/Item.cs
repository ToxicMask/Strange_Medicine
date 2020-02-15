﻿using System.Collections;
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