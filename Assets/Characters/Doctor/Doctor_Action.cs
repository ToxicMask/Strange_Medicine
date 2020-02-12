using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Action : MonoBehaviour
{

    public Doctor_Movement movement_script;

    public Transform action_pivot;

    public LineRenderer red_line;

    public float action_offset = 1;

    public bool edit_mode = true;

    

    // Start is called before the first frame update
    void Start()
    {
        movement_script = GetComponent<Doctor_Movement>();
        action_pivot = GetComponent<Transform>();
        red_line= GetComponentInChildren<LineRenderer>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetButtonDown("Action_Right"))
        {
            Action_Right_Hand();
        }
        else if (Input.GetButtonDown("Action_Left"))
        {
            Action_Left_Hand();
        }
    }


    void Action_Right_Hand()
    {
        RaycastHit2D new_info = Action_Raycast();

        print("RIGHT HAND:" + new_info.point + " Target:" + new_info.collider);
        Report(new_info);
    }



    void Action_Left_Hand()
    {
        print("LEFT HAND");
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
