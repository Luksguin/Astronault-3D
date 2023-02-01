using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> gameObjects;

    [Header("DOTween")]
    public float duration;
    public float delay;
    public Ease ease = Ease.OutBack;

    private void OnEnable()
    {
        HideButtons();
        ShowButtonsWithDelay();
    }

    private void HideButtons()
    {
        foreach(var g in gameObjects)
        {
            g.transform.localScale = Vector3.zero;
            g.SetActive(false);
        }
    }

    private void ShowButtonsWithDelay()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            var g = gameObjects[i];
            g.SetActive(true);
            g.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);
        }
    }
}
