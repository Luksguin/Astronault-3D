using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float spinSpeed;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * spinSpeed * Time.deltaTime, 0);
        var verticalSpeed = transform.forward * Input.GetAxis("Vertical") * speed;

        characterController.Move(verticalSpeed * Time.deltaTime);
    }
}
