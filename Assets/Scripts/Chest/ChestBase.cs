using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public GameObject openIcon;
    public string playerTag;
    public string openTrigger;
    public float iconAnimationduration;
    public Ease iconEase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            ShowIcon();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == playerTag)
        {
            HideIcon();
        }
    }

    public void OpenChest()
    {
        animator.SetTrigger(openTrigger);
    }

    [NaughtyAttributes.Button]
    public void ShowIcon()
    {
        openIcon.transform.DOScale(1, iconAnimationduration).SetEase(iconEase);
    }

    [NaughtyAttributes.Button]
    public void HideIcon()
    {
        openIcon.transform.DOScale(0, iconAnimationduration).SetEase(iconEase);
    }
}
