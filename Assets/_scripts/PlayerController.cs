using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _moveSpeed = 5f;
    
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        var moveDirection = GetMoveDirection();

        if (moveDirection != Vector3.zero)
        {
            _animator.SetTrigger("walk");
            RotatePlayer(moveDirection);
            MovePlayer(moveDirection);
        }
        else
        {
            _animator.SetTrigger("idle");
        }
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
         Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        transform.rotation = Quaternion.Euler(toRotation.eulerAngles.x, toRotation.eulerAngles.y, toRotation.eulerAngles.z);
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    private Vector3 GetMoveDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

         Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;

        return moveDirection;
    }
}
