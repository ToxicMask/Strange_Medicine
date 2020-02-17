using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death_Display_UI : MonoBehaviour
{

    Text display_death;
    string death_template = "Deaths:\n";

    // Start is called before the first frame update
    void Start()
    {
        display_death = GetComponent<Text>();
        Update_Death_Display(0);
    }

    public void Update_Death_Display(int score)
    {
        string string_score = score.ToString();

        display_death.text = death_template + string_score;

    }
}
