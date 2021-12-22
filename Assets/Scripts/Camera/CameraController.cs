using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;

    private void Start()
    {
        cv = GetComponent<CinemachineVirtualCamera>();
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        cv.m_Follow = player;
    }
}
