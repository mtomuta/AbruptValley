using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public void PlayerPosition()
    {
        
    }

    void Start()
    {
        Save();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Load();
        }
    }

    public void Save()
    {
        SaveManager.Save(this);
        Debug.Log("Saved");
    }

    public void Load()
    {
        SaveManager.Load();
    }
}