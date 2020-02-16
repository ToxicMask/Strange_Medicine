using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTimer : MonoBehaviour
{
    //Lap time
    //Pause
    //Reset
    public string commentary;
    public MonoBehaviour target_obj;
    public string target_function;

    public float targetTime = 60.0f;
    public float currentTime = 0;

    public bool active = false;

    public bool one_shot = false;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime += Time.deltaTime;

            if (targetTime <= currentTime)
            {
                OnTimerEnd();
            }
        }
    }

    public void ActiveTimer(bool act)
    {
        active = act;
    }

    public void ResetTimer()
    {
        currentTime = 0.0f;

        if (!active)
        {
            active = true;
        }
    }

    public void RedefineTargetTime(float new_time)
    {
        targetTime = new_time;
        ResetTimer();
    }

    void OnTimerEnd()
    {
        //Execute function
        if (target_obj != null && target_function != "")
        {
            target_obj.Invoke(target_function, 0f);
        }

        // Clamp time
        currentTime = targetTime;

        //Check if is oneshot
        if (!one_shot)
        {
            ResetTimer();
        }
        else
        {
            ActiveTimer(false);
        }
    }
}
