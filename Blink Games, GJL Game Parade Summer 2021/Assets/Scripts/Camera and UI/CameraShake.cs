using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera c;
    CinemachineBasicMultiChannelPerlin cp;
    float shakeTimer, shakeTimerTotal, startingIntensity;
    // Start is called before the first frame update
    void Start()
    {
        cp = c.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            cp.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));
        }
    }

    public void ShakeCamera(float Intensity, float Time)
    {
        cp.m_AmplitudeGain = Intensity;
        startingIntensity = Intensity;
        shakeTimerTotal = Time;
        shakeTimer = Time;
    }
}
