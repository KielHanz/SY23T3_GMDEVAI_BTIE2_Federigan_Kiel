using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float movementSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float inputZ = Input.GetAxis("Horizontal");
        float inputX = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputZ + transform.forward * inputX;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    }
}
