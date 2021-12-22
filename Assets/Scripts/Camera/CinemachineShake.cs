using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cv;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startIntensity;

    private void Awake()
    {
        Instance = this;
        cv = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera (float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cvMCP = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cvMCP.m_AmplitudeGain = intensity;

        startIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin cvMCP = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cvMCP.m_AmplitudeGain = Mathf.Lerp(startIntensity, 0f, (1 - (shakeTimer / shakeTimerTotal)));
        }
    }
}
