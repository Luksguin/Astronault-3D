using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public float duration;
    public float delay;
    public Ease ease;

    private void OnEnable()
    {
        ShowButtonsWithDelay();
    }

    private void ShowButtonsWithDelay()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            var g = gameObjects[i];
            g.SetActive(true);
            g.transform.DOScale(0, duration).SetDelay(i * delay).SetEase(ease).From();
        }
    }
}
