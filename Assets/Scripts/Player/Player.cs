using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float spinSpeed;
    public float gravity;

    private float _vGravity;

    [Header("Animations")]
    public Animator playerAnimator;
    public string runBool;

    private void Moviments()
    {
        var InputAxisVertical = Input.GetAxis("Vertical");
        var verticalSpeed = transform.forward * InputAxisVertical * speed;
        verticalSpeed.y -= gravity;

        characterController.Move(verticalSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime, 0);

        Debug.Log(((int)InputAxisVertical));

        if (InputAxisVertical != 0)
        {
            playerAnimator.SetBool(runBool, true);
        }
        else 
        {
            playerAnimator.SetBool(runBool, false);
        }
    }

    void Update()
    {
        Moviments();
    }
}
