using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeBase : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public float amplitude;
    public float intensify;
    public float duration;

    [SerializeField] private float shakeTime;
    private CinemachineBasicMultiChannelPerlin c;

    public void StartShake()
    {
        Shake(amplitude, intensify, duration);
    }

    private void Awake()
    {
        c = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitude, float intensify, float time)
    {
        if (c == null) return;
        c.m_FrequencyGain = intensify;
        c.m_AmplitudeGain = amplitude;

        shakeTime = time;
    }

    private void Update()
    {
        if(shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            c.m_FrequencyGain = 0;
            c.m_AmplitudeGain = 0;
        }
    }
}
