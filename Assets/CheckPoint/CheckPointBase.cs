using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color onColor;

    public int key;

    //private string _keyString = "CheckPointKey";
    private bool _isCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !_isCheck)
        {
            TurnOn();
            SaveCheckPoint();
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        TurnOff();
    }*/

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
        /*if(PlayerPrefs.GetInt("CheckPointKey", 0) > key)
        {
            PlayerPrefs.SetInt("CheckPointKey", key);
        }*/

        _isCheck = true;

        CheckPointManager.instance.CheckCheckPoint(key);
    }
}
