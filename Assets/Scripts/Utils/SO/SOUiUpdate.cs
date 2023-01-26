using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUiUpdate : MonoBehaviour
{
    public SOInt soIntCoin;
    public TextMeshProUGUI uiText;

    void Update()
    {
        uiText.text = soIntCoin.value.ToString();
    }
}
