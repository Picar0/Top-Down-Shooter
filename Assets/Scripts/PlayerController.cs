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
    private Camera _cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShooting();
    }

    private static void PlayerShooting()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            Weapon.instance.shoot();
        }
    }

    private void PlayerMovement()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = _cam.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,_cam.transform.position.y - transform.position.y));
        targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x,0,transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, _rotationSpeed * Time.deltaTime);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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
