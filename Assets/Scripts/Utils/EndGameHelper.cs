using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGameHelper : MonoBehaviour
{
    public GameObject winMenu;
    public int thisLevel;
    public float animationDuration;
    public Ease animationEase;

    private void Awake()
    {
        winMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (p)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        SaveManager.instance.SaveLastLevel(thisLevel);
        SaveManager.instance.Save();

        winMenu.SetActive(true);
        winMenu.transform.DOScale(0, animationDuration).SetEase(animationEase).From();
    }
}
