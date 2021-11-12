using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    //public Transform player;
    public PlayerController player;
    public float vertical { get { return directionTowardsPlayer.y; } }
    public float horizontal { get { return directionTowardsPlayer.x; } }
    public float playerDistance { get { return directionTowardsPlayer.magnitude; } }
    public Vector2 directionTowardsPlayer { get; private set; }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        DirectionTowardsPlayer();
    }

    void Update()
    {
        DirectionTowardsPlayer();
    }

    private void DirectionTowardsPlayer()
    {
        directionTowardsPlayer = player.transform.position - transform.position;
    }
}
