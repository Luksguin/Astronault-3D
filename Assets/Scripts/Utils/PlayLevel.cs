using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayLevel : MonoBehaviour
{
    public TextMeshProUGUI uiLevel;

    private void Start()
    {
        SaveManager.instance.FileLoaded += OnLoad;
    }

    public void OnLoad(SaveSetup setup)
    {
        uiLevel.text = "Play " + (setup.lastLevel + 1);
    }
}
