using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Patient_Bed : MonoBehaviour
{

    //Patient Bed waiting for treatment

    private List<ITEM_TYPE> required_steps = new List<ITEM_TYPE>();


    // Current Step for the patient treatment

    public int current_step = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        required_steps = New_Template();
    }

    List<ITEM_TYPE> New_Template()
    {

        List<ITEM_TYPE> new_temp = new List<ITEM_TYPE>() {ITEM_TYPE.HEART, ITEM_TYPE.NEEDLE };

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
