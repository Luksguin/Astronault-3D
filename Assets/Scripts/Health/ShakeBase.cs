using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeBase : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public float amplitude;
    public float frequency;
    public float duration;

    public float shakeTime;

    [SerializeField] private CinemachineBasicMultiChannelPerlin c;

    [NaughtyAttributes.Button]
    public void StartShake()
    {
        Shake(amplitude, frequency, duration);
    }

    private void Awake()
    {
        //c = cinemchine.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(float amplitude, float intensify, float time)
    {
        c = cinemachine.GetComponent<CinemachineBasicMultiChannelPerlin>();

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
            c.m_FrequencyGain = 0;
        }
    }
}
