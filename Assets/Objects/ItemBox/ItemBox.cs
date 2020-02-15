using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public Animator anim_control;
    public GameObject item_display;
    public Icon_Item item_icon;

    public Item stored_item;

    //To be erased
    public int item_id = -1;

    //To be used
    public ITEM_TYPE item_enum = ITEM_TYPE.EMPTY;

    // Start is called before the first frame update
    void Start()
    {

        anim_control = GetComponent<Animator>();
        item_display = this.gameObject.transform.Find("Icon_Display").gameObject;
        item_icon = item_display.transform.Find("Icon").GetComponent<Icon_Item>();

        if (item_id > -1)
        {
            stored_item = new Item(item_id);
            item_icon.Set_New_Icon(item_id);
        }
        
    }


    public Item Open_Box()
    {
        anim_control.SetBool("Opened", true);
        Display_Panel(false);
        return stored_item;
    }

    public void Close_Box()
    {
        Display_Panel(true);
        anim_control.SetBool("Opened", false);
    }

    public void Display_Panel(bool act)
    {
        item_display.SetActive(act);
    }
}
