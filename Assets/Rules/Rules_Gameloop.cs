using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rules_Gameloop : MonoBehaviour
{
    public Score_Display_UI score_ui;

    public Death_Display_UI death_ui;

    public Score_Manager score_manager;

    public List<Door_Spawn_Script> all_doors;

    //List of possible objective
    public bool need_all_doors_cleared = true;

    public bool has_death_limit = true;

    public int current_score = 0;

    public int current_dead = 0;


    // Number of deaths that will trigger a game over
    public int  death_limit = 3;


    // Start is called before the first frame update
    void Start()
    {
        //Find and Set Score Manager // Pass to next Scene
        GameObject current_manager = GameObject.FindGameObjectWithTag("Score_Manager");
        score_manager = current_manager.GetComponent<Score_Manager>();


        //Find and set Score Display UI // Display to Player


        // Get all child doors
        foreach (Transform child in transform)
        {
            all_doors.Add(child.gameObject.GetComponent<Door_Spawn_Script>());
        }

        //Reset Canvas values
        //Update_Score_Display(0);
        //Update_Death_Display(0);
    }

    void Update_Score_Display(int new_score)
    {
        score_ui.Update_Score_Display(new_score);
    }

    void Update_Death_Display(int new_death)
    {
        death_ui.Update_Death_Display(new_death);
    }

    public void Increase_Current_Score(int plus_score)
    {
        current_score += plus_score;
        Update_Score_Display(current_score);
    }

    public void Increase_Current_Dead()
    {
        current_score += -100;
        current_dead++;
        Update_Score_Display(current_score);
        Update_Death_Display(current_dead);
    }

    bool Check_All_Doors()
    {
        bool all_doors_cleared = true;

        foreach(Door_Spawn_Script door in all_doors)
        {
            if (!door.queue_completed)
            {
                all_doors_cleared = false;
            }
        }
        return all_doors_cleared;
    }


    // Just checks if the level ends
    public void Check_Endgame()
    {
        // Checks each end game conditions

        // Limit of failed patients
        if (has_death_limit)
        {
            if (current_dead >= 3)
            {
                Level_End();
            }
        }

        // Check if all doors are cleared
        if (need_all_doors_cleared)
        {
            if (Check_All_Doors())
            {
                Level_End();
            }
        }
    }


    // Checks Victory conditions
    void Level_End()
    {

        //Disable tags
        List<string> disable_tags = new List<string> { "Player", "Patient", "Icon_Display", "Patient_SpawnPoint", };

        // Disable Tag componets

        // Disable all taged objects
        foreach (string tag in disable_tags)
        {
            foreach (GameObject target in GameObject.FindGameObjectsWithTag(tag))
            {
                target.SetActive(false);
            }
        }




        // Checks the dead (Cond / Limit)
        if (has_death_limit)
        {
            if (current_dead < death_limit)
            {
                Victory();
            }
            else
            {
                Defeated();
            }
        }
    }


    void Victory()
    {
        print("Victory");
        Quit_Game_to_Score_Menu();
    }


    void Defeated()
    {
        print("Defeated");
        Quit_Game_to_Score_Menu();
    }


    void Quit_Game_to_Score_Menu()
    {

        if (score_manager != null)
        {
            // Set current score as final score
            //Pass to next scene
            score_manager.final_score = current_score;
            score_manager.final_deaths = current_dead;
        }

        print("Quit_Game");
        SceneManager.LoadScene("Menus/Score_Menu/Score_Menu", LoadSceneMode.Single);
    }

}
