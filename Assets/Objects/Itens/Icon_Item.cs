using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_Item : MonoBehaviour
{
    public SpriteRenderer sprite_comp;

    public Sprite[] icon_item;

    public int icon_id = -1;

    // Start is called before the first frame update
    void Start()
    {
        sprite_comp = GetComponent<SpriteRenderer>();

    }
    public void Set_New_Icon(int new_icon)
    {
        icon_id = new_icon;

        if (icon_id != -1)
        {
            sprite_comp.sprite = icon_item[icon_id];
        }
    }
}
