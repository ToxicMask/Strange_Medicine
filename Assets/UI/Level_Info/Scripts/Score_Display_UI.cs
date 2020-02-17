using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Display_UI : MonoBehaviour
{

    Text display_score;
    string score_template = "Score:\n";

    // Start is called before the first frame update
    void Start()
    {
        display_score = GetComponent<Text>();
        Update_Score_Display(0);
    }

    public void Update_Score_Display(int score)
    {
        string string_score = score.ToString();

        display_score.text = score_template + string_score;

    }
}
