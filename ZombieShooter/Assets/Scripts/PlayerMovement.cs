using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float movementSpeed = 5f;
    private Animator animator;
    private CharacterController characterController;
    private int kSpeed;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        kSpeed = Animator.StringToHash("Speed");
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseHorizontal = Input.GetAxis("Mouse X"); 
        animator.SetFloat(kSpeed, vertical);
        if (Input.GetMouseButton(1) == false)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed);
        }
        characterController.SimpleMove(transform.forward * movementSpeed * vertical);
    }
}
