using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Handler
    [SerializeField] private float _rotationSpeed = 450;
    [SerializeField] private float _walkSpeed = 5;
    [SerializeField] private float _runSpeed = 8;

    //System
    private Quaternion targetRotation;

    //Components
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, _rotationSpeed * Time.deltaTime);
        }
        if (Input.GetButton("Run"))
        {
            Vector3 motion = input.normalized * _runSpeed;
            controller.Move(motion * Time.deltaTime);
        }
        else
        {
            Vector3 motion = input.normalized * _walkSpeed;
            controller.Move(motion * Time.deltaTime);
        }
    }
}
