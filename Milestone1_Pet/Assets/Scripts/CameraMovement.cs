using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform player;

    private float rotationX;
    private float rotationY;

    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //calculates rotation of camera based on mouse input
        rotationX -= mouseY;
        //limits player to do a full 360 rotation up and down
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        rotationY += mouseX;

        //rotates camera up and down
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        //rotate player game object left and right
        player.transform.rotation = Quaternion.Euler(0, rotationY, 0f);
    }
}
