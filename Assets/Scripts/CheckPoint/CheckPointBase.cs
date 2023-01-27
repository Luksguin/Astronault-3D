using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color onColor;

    [Header("Animation")]
    public GameObject message;
    public float durationMessageAnimation;
    public float timeOfMessageInScreen;
    public Ease easeMessageAnimation;

    public int key;

    private bool _isCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !_isCheck)
        {
            TurnOn();
            StartCoroutine(ShowMessage());
            SaveCheckPoint();
        }
    }

    IEnumerator ShowMessage()
    {
        message.transform.DOScale(1, durationMessageAnimation).SetEase(easeMessageAnimation);
        yield return new WaitForSeconds(timeOfMessageInScreen);
        message.transform.DOScale(0, durationMessageAnimation).SetEase(easeMessageAnimation);
    }

    private void TurnOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", onColor);
    }

    private void TurnOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.gray);
    }

    private void SaveCheckPoint()
    {

        _isCheck = true;

        CheckPointManager.instance.CheckCheckPoint(key);
    }
}
