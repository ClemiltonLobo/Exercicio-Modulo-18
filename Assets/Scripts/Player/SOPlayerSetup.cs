using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedRun;
    public float speed;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleY = 0.7f;
    public float jumpScaleX = 1.5f;
    public float squatScaleX = 1.5f;
    public float squatScaleY = 0.7f;
    public float animatioDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;
}
