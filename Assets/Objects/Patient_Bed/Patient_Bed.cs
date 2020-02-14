using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Patient_Bed : MonoBehaviour
{

    //Patient Bed waiting for treatment

    private List<ITEM_TYPE> required_steps = new List<ITEM_TYPE>();


    // Current Step for the patient treatment

    public int current_step = 0;

    // Bed treatment template ids

    public int template_id = 0;


    // Start is called before the first frame update
    void Start()
    {
        required_steps = New_Template(template_id);
    }

    List<ITEM_TYPE> New_Template(int template_id)
    {

        List<ITEM_TYPE> new_temp = new List<ITEM_TYPE>();

        switch (template_id)
        {
            // Only Tools

            case 0:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SCISSOR };
            break;
            
            case 1:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SAW };
            break;
            
            case 2:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.HAMMER};
            break;
        }


        return new_temp;
    }

    public void _Check_Treatment(int item_used)
    {
        if (item_used == (int)required_steps[current_step])
        {
            //if is not the last step;
            //Next Step
            if (current_step < required_steps.Count -1) {
                
                current_step++;
                print("Next Step");
            }

            // Last step
            else if (current_step == required_steps.Count - 1)
            {
                Object.Destroy(gameObject);
            }
            
        }
        else
        {
            Debug.Log(" Wrong item used! " + item_used);
        }
    }

}
