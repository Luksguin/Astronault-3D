using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Speed")]
    public float speed;
    public float speedRun;
    public float forceJump;

    [Header("Animations")]
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;

    [Header("Animations States")]
    public string boolRun;
    public string boolJump;

    public Ease ease = Ease.OutBack;
}
