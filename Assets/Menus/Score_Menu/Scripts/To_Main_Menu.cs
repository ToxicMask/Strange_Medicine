using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    public void Change_to_Main_Menu()
    {
        SceneManager.LoadScene("Menus/Main_Menu/Main_Menu", LoadSceneMode.Single);
    }

}
