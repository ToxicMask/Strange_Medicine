using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public Item stored_item = new Item(0);

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public Item Open_Box()
    {
        return stored_item;
    }
}
