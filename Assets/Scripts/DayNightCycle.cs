using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    public Text timeDisplay; 
    public Volume postProcessingVolume;

    public float tick;
    public float seconds;
    public int mins;
    public int hours;

    public bool activeLights;
    public GameObject[] lights;

    private static bool gameVolume;

    void Start()
    {
        timeDisplay = GameObject.FindWithTag("Timer").GetComponent<Text>();
        postProcessingVolume = gameObject.GetComponent<Volume>();

        if (!gameVolume)
        {
            gameVolume = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() 
    {
        CalculateTime();
        DisplayTime();
    }

    public void CalculateTime()
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60)
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60)
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24)
        {
            hours = 0;
        }
        ControlPPV();
    }

    public void ControlPPV() 
    {
        if (hours >= 21 && hours < 22) 
        {
            postProcessingVolume.weight = (float)mins / 60; 

            if (activeLights == false)
            {
                if (mins > 45) 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); 
                    }
                    activeLights = true;
                }
            }
        }

        if (hours >= 6 && hours < 7) 
        {
            postProcessingVolume.weight = 1 - (float)mins / 60; 

            if (activeLights == true) 
            {
                if (mins > 45) 
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); 
                    }
                    activeLights = false;
                }
            }
        }
    }

    public void DisplayTime() 
    {
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); 
    }
}