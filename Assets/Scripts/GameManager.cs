using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public static GameManager instance { get; private set; }
    //public Transform playerSpawnPoint;
    public PlayerController player;

    private static bool gameManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = GameObject.Find("SpawnPoint").transform.position;

        if (!gameManager)
        {
            gameManager = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}