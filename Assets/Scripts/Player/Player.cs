using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ebac.Core.Singleton;
using Armor;

public class Player : Singleton<Player>
{
    [Header("Moviments")]
    public CharacterController characterController;
    public float speed;
    public float speedRunnig;
    public float jumpForce;
    public float spinSpeed;
    public float gravity;

    private float _vGravity;

    [Header("Animator")]
    public Animator playerAnimator;
    public string idleTrigger;
    public string runBool;
    public string jumpBool;
    public string deathTrigger;

    [Header("Damage")]
    public List<FlashColor> flashColors;
    public List<ShakeBase> shake;
    public HealthBase healthBase;
    public GameObject loseScreen;
    public float timeToRevive;
    public float durationLoseScreenAnimation;
    public Ease easeLoseScreenAnimation;

    [Header("Armor")]
    public ArmorPlayer armorPlayer;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    protected override void Awake()
    {
        base.Awake();

        OnValidate();

        healthBase.onDamage += Damage;
        healthBase.onKill += KillPlayer;
    }

    public void KillPlayer(HealthBase h)
    {
        playerAnimator.SetTrigger(deathTrigger);

        Invoke(nameof(ShowMenu), timeToRevive);
    }

    public void Revive()
    {
        if (CheckPointManager.instance.HasCheckPoint())
        {
            Respawn();
            playerAnimator.SetTrigger(idleTrigger);
            healthBase.ResetLife();
            healthBase.colliders.ForEach(i => i.enabled = true);
            HideMenu();
        }
    }

    #region MENU
    private void ShowMenu()
    {
        loseScreen.transform.DOScale(1, durationLoseScreenAnimation).SetEase(easeLoseScreenAnimation);
    }

    private void HideMenu()
    {
        loseScreen.transform.DOScale(0, durationLoseScreenAnimation).SetEase(easeLoseScreenAnimation);
    }
    #endregion

    #region INTERFACE
    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash());
        PostProcessingManager.instance.ShowVignette();
        shake.ForEach(i => i.StartShake());
    }

    public void DamageVector(int damage, Vector3 dir) { }
    #endregion

    #region MOVIMENTS
    private void Run()
    {
        if (characterController.enabled == false) return;

        transform.Rotate(0, Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= speedRunnig;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= speedRunnig;
        
        var InputVertical = Input.GetAxis("Vertical");
        var run = transform.forward * InputVertical * speed;

        _vGravity -= gravity * Time.deltaTime;
        run.y = _vGravity;
        characterController.Move(run * Time.deltaTime);

        if (InputVertical != 0)
        {
            playerAnimator.SetBool(runBool, true);
        }
        else 
        {
            playerAnimator.SetBool(runBool, false);
        }
    }

    private void Jump()
    {
        if (characterController.enabled == false) return;

        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _vGravity = jumpForce;
                playerAnimator.SetBool(jumpBool, true);
            }
            else
            {
                playerAnimator.SetBool(jumpBool, false);
            }
        }
    }

    void Update()
    {
        Run();
        Jump();
    }
    #endregion 

    private void Respawn()
    {
        if (CheckPointManager.instance.HasCheckPoint())
        {
            transform.position = CheckPointManager.instance.GetPosition();
        }
    }

    #region ARMOR
    public void UpSpeed(float speed, float duration)
    {
        StartCoroutine(UpSpeedCoroutine(speed, duration));
    }

    IEnumerator UpSpeedCoroutine(float newSpeed, float duration)
    {
        var startSpeed = speed;
        speed = newSpeed;
        yield return new WaitForSeconds(duration);
        speed = startSpeed;
    }

    public void UpdateArmor(ArmorSetup setup, float duration)
    {
        StartCoroutine(UpdateArmorCoroutine(setup, duration));
    }

    IEnumerator UpdateArmorCoroutine(ArmorSetup setup, float duration)
    {
        armorPlayer.ChangeArmor(setup);
        yield return new WaitForSeconds(duration);
        armorPlayer.ResetArmor();
    }
    #endregion
}
