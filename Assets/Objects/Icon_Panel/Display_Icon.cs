using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Icon : MonoBehaviour
{
    public Animator anim_control;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        anim_control = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Display_Panel(bool act)
    {
        sprite.enabled = act;
    }
}
