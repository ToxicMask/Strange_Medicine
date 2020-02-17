using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Display : MonoBehaviour
{

    public int new_score = 0;

    public Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        score_text = GetComponent<Text>();

        //Find and delete new score manager
        GameObject score_manager = GameObject.FindGameObjectWithTag("Score_Manager");

        if (score_manager != null)
        {
            //Update score
            new_score = score_manager.GetComponent<Score_Manager>().final_score;

            // Delete Score Manager
            //this.Invoke
            Object.Destroy(score_manager);
        }


        score_text.text = new_score.ToString();
    }

}
