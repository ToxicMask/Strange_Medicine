using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Spawn_Script : MonoBehaviour
{

    public GameObject patient_prefab;

    private Vector3 offset_spawpoint = new Vector3(0, -1, 0);

    // Timer script
    private ScriptTimer spawn_timer;

    // Animator
    private Animator anim_control;

    public List<Patient_Bed.TEMPLATE_LIST> queue_templates = new List<Patient_Bed.TEMPLATE_LIST>();

    public int current_template_id = 0;



    // Start is called before the first frame update
    void Start()

        // Set current template
    {

        anim_control = GetComponent<Animator>();
        spawn_timer = GetComponent<ScriptTimer>();
        //Spawn_Patient_Bed(current_template);
    }

    void Prepare_Bed_Spawn()
    {
        anim_control.SetBool("Spawning", true);
    }

    void Spawn_Patient_Bed()
    {
        // Spawning bool
        anim_control.SetBool("Spawning", false);

        if (current_template_id < queue_templates.Count)
        {

            GameObject new_instance = Instantiate(patient_prefab);

            new_instance.transform.parent = transform;
            new_instance.transform.position = transform.position + offset_spawpoint;

            Patient_Bed script = new_instance.GetComponent<Patient_Bed>();
            script.name = script.name.Replace("(Clone)", "");
            script.template_id = queue_templates[current_template_id];
            current_template_id++;
        }

        else
        {
            Object.Destroy(gameObject);
        }
    }

    public void Patient_Cleared()
    {
        if (current_template_id < queue_templates.Count)
        {
            spawn_timer.ResetTimer();
        }
        else
        {
            print("Done");
        }
    }
}
