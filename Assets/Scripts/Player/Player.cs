using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;

    void Update()
    {
        var verticalSpeed = transform.forward * Input.GetAxis("Vertical") * speed;

        characterController.Move(verticalSpeed * Time.deltaTime);
    }
}
