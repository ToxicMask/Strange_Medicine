using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public Animator anim_control;

    public Item stored_item;
    public int item_id = -1;

    // Start is called before the first frame update
    void Start()
    {

        anim_control = GetComponent<Animator>();

        if (item_id > -1)
        {
            stored_item = new Item(item_id);
        }
    }


    public Item Open_Box()
    {
        anim_control.SetBool("Opened", true);
        return stored_item;
    }

    public void Close_Box()
    {
        anim_control.SetBool("Opened", false);
    }
}
