using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_Item : MonoBehaviour
{
    public SpriteRenderer sprite_comp;

    public Sprite[] icon_item;

    public ITEM_TYPE icon_id = ITEM_TYPE.EMPTY;

    // Start is called before the first frame update
    void Start()
    {
        sprite_comp = GetComponent<SpriteRenderer>();

    }
    public void Set_New_Icon(ITEM_TYPE new_icon)
    {
        icon_id = new_icon;

        if (icon_id != ITEM_TYPE.EMPTY)
        {
            sprite_comp.sprite = icon_item[(int)icon_id];
        }
    }
}
