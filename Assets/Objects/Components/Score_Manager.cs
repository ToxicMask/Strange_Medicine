﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Manager : MonoBehaviour
{

    public int final_score = 0;

    public int final_deaths = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
