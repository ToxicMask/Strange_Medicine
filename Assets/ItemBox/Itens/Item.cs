using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item 
{

    public enum ITEM_TYPE
    {
        NEEDLE,
        SAW,
        COUNT
    } 

    public string[] string_names = new string[] { "Needle", "Saw" };

    public int item_id = -1;
    public string name = "";

    public Item(int id)
    {
        
        this.item_id = id;

        this.name = string_names[id];
    }
}