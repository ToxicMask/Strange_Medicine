using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules_Template : MonoBehaviour
{

    public bool endless_night = false;
    bool all_doors_cleared = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void Check_If_Level_Ends()
    {

        if (all_doors_cleared)
        {
            Level_End();
        }

    }



    void Level_End()
    {
        if (Check_Win_Cond())
        {
            Victory();
        }
        else
        {
            Defeated();
        }
    }


    bool Check_Win_Cond()
    {
        return true;
    }


    void Victory()
    {
        print("Victory");
    }


    void Defeated()
    {
        print("Defeated");
    }


    void Quit_Game_to_MainMenu()
    {
        print("Quit_Game");
    }

}
