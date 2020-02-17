using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Levels/Demo/Demo1", LoadSceneMode.Single);
    }


    public void Play_Demo()
    {
        SceneManager.LoadScene("Levels/Demo/Demo1", LoadSceneMode.Single);
    }
}

