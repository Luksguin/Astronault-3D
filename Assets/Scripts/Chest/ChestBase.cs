using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public GameObject openIcon;
    public KeyCode openChest;
    public string playerTag;
    public string openTrigger;
    public float iconAnimationduration;
    public Ease iconEase;

    private bool _showIcon = false;
    private bool _isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == playerTag && _isOpen == false)
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
        if (_showIcon == true)
        {
            _isOpen = true;
            animator.SetTrigger(openTrigger);
            HideIcon();
        }
    }
        public void ShowIcon()
    {
        _showIcon = true;
        openIcon.transform.DOScale(1, iconAnimationduration).SetEase(iconEase);
    }

    public void HideIcon()
    {
        _showIcon = false;
        openIcon.transform.DOScale(0, iconAnimationduration).SetEase(iconEase);
    }

    private void Update()
    {
        if (Input.GetKeyDown(openChest))
        {
            OpenChest();
        }
    }
}
