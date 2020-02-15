using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    public Image item_sprite_render;

    public Text item_name_display;

    public string[] string_names = new string[] { "Scissor", "Saw", "Hammer", "Brain", "Heart", "Leg" };

    public Sprite[] icon_item = new Sprite[6];

    public ITEM_TYPE current_item = ITEM_TYPE.EMPTY;

    // Start is called before the first frame update
    void Start()
    {

        Update_Inventory_Item(current_item);
    }


    public void Update_Inventory_Item(ITEM_TYPE new_item)
    {

        current_item = new_item;

        if ((int)new_item == -1)
        {
            //print("EMPTY");
            item_sprite_render.color = new Color(0f, 0f, 0f, 0f);
            item_name_display.text = "EMPTY HAND";
            return;
        }

        else if ((int)new_item < (int)ITEM_TYPE.COUNT)
        {
            //print("Done");
            item_sprite_render.color = new Color(255f, 255f, 255f, 1f);
            item_sprite_render.sprite = icon_item[(int)new_item];
            item_name_display.text = string_names[(int)new_item];
        }
    }
}
