using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField]
    float speedModifier = 0.0001f;
    [SerializeField]
    float turnModifier = 5;
    [SerializeField]
    float gravity = 20f;

    float velocity_x = 0f;
    float velocity_y = 0f;
    float velocity_z = 0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void ApplyVelocity()
    {
        characterController.Move(new Vector3(velocity_x, velocity_y, velocity_z));
    }
    void Update()
    {
        //get movement axis input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (characterController.isGrounded)
        {
            if (move.Equals(Vector3.zero))
            {
                velocity_x *= 0.5f;
                velocity_z *= 0.5f;
                animator.SetInteger("Movement", 0);
            }
            else
            {
                move = Vector3.Normalize(move);

                Quaternion newRotation = Quaternion.LookRotation(move, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, turnModifier);
                velocity_x = (move.x * Time.deltaTime * speedModifier);
                velocity_z = (move.z * Time.deltaTime * speedModifier);
                animator.SetInteger("Movement", 1);
            }
        }
        else
        {
            velocity_y -= gravity*Time.deltaTime;
        }

        ApplyVelocity();
    }
}
