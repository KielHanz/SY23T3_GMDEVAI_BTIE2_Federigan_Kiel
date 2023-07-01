using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]private float movementSpeed;

    private float gravity = -9.81f * 2f;

    private bool isGrounded;

    Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputY;

        characterController.Move(move * movementSpeed* Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }

}
