using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Moviments")]
    public CharacterController characterController;
    public float speed;
    public float jumpForce;
    public float spinSpeed;
    public float gravity;

    private float _vGravity;

    [Header("Animations")]
    public Animator playerAnimator;
    public string runBool;
    public string jumpBool;
    public string deathTrigger;

    [Header("Life")]
    public List<FlashColor> flashColors;
    public HealthBase healthBase;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();

        healthBase.onDamage += Damage;
        healthBase.onKill += KillAnimation;
    }

    public void KillAnimation(HealthBase h)
    {
        playerAnimator.SetTrigger(deathTrigger);
    }

    #region INTERFACE
    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash());
    }

    public void DamageVector(int damage, Vector3 dir) { }
    #endregion

    #region MOVIMENTS
    private void Run()
    {
        if (characterController.enabled == false) return;

        transform.Rotate(0, Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= 2;
        
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
    #endregion 

    void Update()
    {
        Run();
        Jump();
    }
}
