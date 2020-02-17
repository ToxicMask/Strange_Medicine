using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Patient_Bed : MonoBehaviour
{

    // Patient Bed waiting for treatment

    private List<ITEM_TYPE> required_steps = new List<ITEM_TYPE>();

    // Icon Panel

     public Icon_Item current_icon;

    //Parent component

    Door_Spawn_Script spawn_bed;

    // Shader for death timer

    Material life_gauge;

    // Script timer

    ScriptTimer timer;


    // Score for completion (Urgent, Medium, Excelent)
    public int[] score_range = new int[] { 50, 150, 300 };

    // Steps for suceffull treatment
    public float[] scores_steps = new float[] { .5f, .75f, 1f };
    // Current Step for the patient treatment

    public int current_step = 0;

    // Bed treatment template ids

    public TEMPLATE_LIST template_id = TEMPLATE_LIST.SCISSOR;
    public enum TEMPLATE_LIST { SCISSOR, SAW, HAMMER, SAW_HAMMER, NEW_LEG= 10, NEW_HEART, NEW_BRAIN };



    // Start is called before the first frame update
    void Start()
    {
        // Components
        spawn_bed = GetComponentInParent<Door_Spawn_Script>();
        life_gauge = transform.Find("Icon_Panel").GetComponent<Renderer>().material;
        timer = GetComponent<ScriptTimer>();


        // Stats var treatment
        current_step = 0;
        required_steps = New_Template(template_id);
        Update_Icon_Panel(required_steps[current_step]);


        // Config Components
        Update_Timer();

    }



    private void Update()
    {

        float current_progress = Get_Timer_Progress();
        //Update Life Gauge
        life_gauge.SetFloat("_Progress", current_progress);

        // Set Color Tint
        if (current_progress < scores_steps[0])
        {
            life_gauge.SetColor("_Progress_Tint_Color", new Color(.4f, .9f, .3f, 1));
        }
        else if (current_progress < scores_steps[1])
        {
            life_gauge.SetColor("_Progress_Tint_Color", new Color(.8f, .9f, .3f, 1));
        }
        else
        {
            life_gauge.SetColor("_Progress_Tint_Color", new Color(.9f,.3f,.3f, 1));
        }
        
    }



    List<ITEM_TYPE> New_Template(TEMPLATE_LIST template_id)
    {

        List<ITEM_TYPE> new_temp = new List<ITEM_TYPE>();

        switch (template_id)
        {
            // Only Tools

            case TEMPLATE_LIST.SCISSOR:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SCISSOR };
            break;
            
            case TEMPLATE_LIST.SAW:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SAW };
            break;
            
            case TEMPLATE_LIST.HAMMER:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.HAMMER};
            break;

            case TEMPLATE_LIST.SAW_HAMMER:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SAW, ITEM_TYPE.HAMMER};
            break;

            // Organ + Tools

            case TEMPLATE_LIST.NEW_LEG:
            new_temp = new List<ITEM_TYPE>() {  ITEM_TYPE.SAW, ITEM_TYPE.LEG};
            break;

            case TEMPLATE_LIST.NEW_HEART:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.SCISSOR, ITEM_TYPE.HEART};
            break;

            case TEMPLATE_LIST.NEW_BRAIN:
            new_temp = new List<ITEM_TYPE>() { ITEM_TYPE.HAMMER, ITEM_TYPE.BRAIN};
            break;
        }


        return new_temp;
    }



    public void _Check_Treatment(ITEM_TYPE item_used)
    {
        if (item_used == required_steps[current_step])
        {
            //if is not the last step;
            //Next Step
            if (current_step < required_steps.Count -1) {
                
                current_step++;
                Update_Icon_Panel(required_steps[current_step]);
                Update_Timer();
                //print("Next Step");
            }

            // Last step
            else if (current_step == required_steps.Count - 1)
            {
                Patient_Lived();
            }
            
        }
        else if (item_used != ITEM_TYPE.EMPTY)
        {
            Patient_Died();
        }
    }


    public void Patient_Died()
    {
        print("Died");
        spawn_bed.Patient_Cleared(false);
        Object.Destroy(gameObject);
    }

    public void Patient_Lived()
    {
        int plus_score = 0;

        float current_progress = Get_Timer_Progress();
        if (current_progress < scores_steps[0])
        {
            plus_score = score_range[2];
        }
        else if (current_progress < scores_steps[1])
        {
            plus_score = score_range[1];
        }
        else
        {
            plus_score = score_range[0];
        }

        print("Lived");
        spawn_bed.Patient_Cleared(true, plus_score);
        Object.Destroy(gameObject);
    }

    float Get_Timer_Progress()
    {
        float target_time = timer.targetTime;
        return timer.currentTime / target_time;
    }

    public void Update_Icon_Panel(ITEM_TYPE new_icon)
    {
        current_icon.Set_New_Icon(new_icon);
    }

    void Update_Timer()
    {
        float time_limit = 0;

        switch (required_steps[current_step])
        {
            case ITEM_TYPE.SCISSOR:

                time_limit = 30;

                break;

            case ITEM_TYPE.SAW:
            case ITEM_TYPE.LEG:

                time_limit = 20;

                break;

            case ITEM_TYPE.HAMMER:
            case ITEM_TYPE.HEART:

                time_limit = 15;

                break;

            case ITEM_TYPE.BRAIN:

                time_limit = 10;

                break;
        }

        // If is first surgery/ set value; Else / Add value;

        if (current_step == 0)
        {
            timer.targetTime = time_limit;
        }
        else
        {
            timer.targetTime += time_limit;
        }

    }
}
