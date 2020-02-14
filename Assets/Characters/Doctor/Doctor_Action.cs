using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Action : MonoBehaviour
{

    // Components
    public Doctor_Movement movement_script;

    public Transform action_pivot;

    public LineRenderer red_line;

    // Action variables
    public float action_offset = 1f;

    //Empty item
    public Item item_slot = new Item(-1);


    // Edit mode
    public bool edit_mode = false;

    

    // Start is called before the first frame update
    void Start()
    {
        movement_script = GetComponent<Doctor_Movement>();
        action_pivot = GetComponent<Transform>();
        red_line= GetComponentInChildren<LineRenderer>(); 
    }



    // Update is called once per frame
    void Update()
    {

        // Primaty action: Use Item Action
        if ( Input.GetButtonDown("Action_Primary"))
        {
            Use_Item();
        }

        // Secundary action: Pick Up
        else if (Input.GetButtonDown("Action_Secundary"))
        {
            Pick_Up_Item();
        }
    }



    // Use equiped item
    void Use_Item()
    {
        // Project raycast for action
        RaycastHit2D new_info = Action_Raycast();

        // Match new info to target type
        if (new_info)
        {
            Patient_Bed current_patient = new_info.transform.GetComponent<Patient_Bed>();

            if (current_patient != null)
            {
                current_patient._Check_Treatment(item_slot.item_id);
                //print("Item: Used");
                return;
            }
        }
        //print("Item: " + item_slot.name);
    }



    // Pick new item
    void Pick_Up_Item()
    {
        // Project raycast for action
        RaycastHit2D new_info = Action_Raycast();

        // Match new info to target type
        if (new_info)
        {
            // Item box
            ItemBox current_itembox = new_info.transform.GetComponent<ItemBox>();

            if (current_itembox != null)
            {
                Item new_tool = current_itembox.Open_Box();

                item_slot = new_tool;
                //print(item_slot.name);
                return;
            }
        }
    }



    RaycastHit2D Action_Raycast()
    {
        return Physics2D.Raycast(action_pivot.position, movement_script.sight_vector, action_offset);
    }



    void Report(RaycastHit2D new_info)
    {
        if (edit_mode)
        {
            
            red_line.SetPosition(0, action_pivot.position);

            if (new_info.collider != null)
            {
                red_line.SetPosition(1, new_info.point);
            }
            else
            {
                Vector3 false_distance = new Vector3(movement_script.sight_vector.x, movement_script.sight_vector.y, 0);
                red_line.SetPosition(1, action_pivot.position + false_distance);
            }
        }
    }
}
