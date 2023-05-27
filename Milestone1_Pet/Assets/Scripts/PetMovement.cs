using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

        Vector3 direction = targetPosition - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);

        if(distance > 1.5f)
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
