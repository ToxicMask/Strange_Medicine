using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death_Display : MonoBehaviour
{
    public int new_death = 0;

    public Text death_text;

    // Start is called before the first frame update
    void Start()
    {
        death_text = GetComponent<Text>();

        //Find and delete new score manager
        GameObject death_manager = GameObject.FindGameObjectWithTag("Score_Manager");

        if (death_manager != null)
        {
            //Update score
            new_death = death_manager.GetComponent<Score_Manager>().final_deaths;

            // Delete Score Manager
            Object.Destroy(death_manager);
        }


        death_text.text = "Total Deaths: " + new_death.ToString();
    }
}
