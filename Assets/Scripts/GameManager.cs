using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public Transform playerSpawnPoint;
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
        playerSpawnPoint = FindObjectOfType<SpawnPoint>().transform;
        player = FindObjectOfType<PlayerController>();
        player.transform.position = playerSpawnPoint.position;

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

    void Update()
    {
        //playerSpawnPoint = FindObjectOfType<RespawnPoint>().transform;
        //playerSpawnPoint.position = new Vector2(-11, 28);
    }
}