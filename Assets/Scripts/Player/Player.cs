using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D MyRigidbody2D;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    public Animator animator;

    private float _currentSpeed;
    //private bool _isRunning = false;


    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.onKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        if (healthBase != null)
            healthBase.onKill -= OnPlayerKill;
        animator.SetTrigger(soPlayerSetup.triggerDeath);
    }

    public void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed =soPlayerSetup.speedRun;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speedRun;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyRigidbody2D.velocity = new Vector2(-_currentSpeed, MyRigidbody2D.velocity.y);
            if(MyRigidbody2D.transform.localScale.x != -1)
            {
                MyRigidbody2D.transform.DOScaleX(-1,soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {            
            MyRigidbody2D.velocity = new Vector2(_currentSpeed, MyRigidbody2D.velocity.y);
            if (MyRigidbody2D.transform.localScale.x != 1)
            {
                MyRigidbody2D.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            animator.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);
        }


        if (MyRigidbody2D.velocity.x > 0)
        {
            MyRigidbody2D.velocity +=soPlayerSetup.friction;
        }
        else if (MyRigidbody2D.velocity.x < 0)
        {
            MyRigidbody2D.velocity -= soPlayerSetup.friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyRigidbody2D.velocity = Vector2.up * soPlayerSetup.forceJump;
            MyRigidbody2D.transform.localScale = Vector2.one;

            DOTween.Kill(MyRigidbody2D.transform);

            HandleScaleJump();
            HandleScaleSquat();
        }
    }

    private void HandleScaleJump()
    {
        MyRigidbody2D.transform.DOScaleY(soPlayerSetup.jumpScaleY,soPlayerSetup.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        MyRigidbody2D.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    private void HandleScaleSquat()
    {
        MyRigidbody2D.transform.DOScaleY(soPlayerSetup.squatScaleY,soPlayerSetup.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        MyRigidbody2D.transform.DOScaleX(soPlayerSetup.squatScaleX,soPlayerSetup.animatioDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
