using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaveMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode pauseButton;
    public int thisLevel;
    public float animationDuration;
    public Ease ease;

    private void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            pauseMenu.SetActive(true);
            pauseMenu.transform.DOScale(1, animationDuration).SetEase(ease);
        }
    }

    public void SaveGame()
    {
        SaveManager.instance.SaveLastLevel(thisLevel);
        pauseMenu.transform.DOScale(0, animationDuration).SetEase(ease);
    }
}
