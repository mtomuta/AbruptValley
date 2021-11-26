using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attributes attributes;
    public int xp;

    public void GiveXp()
    {
        GameManager.instance.player.GetComponent<LvlExperience>().xp += xp;
    }
}
