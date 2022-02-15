using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentCC : MonoBehaviour
{
    CharacterController CharCont;
    float yVelocity;
    float HyperJump  = 1;
    bool PressedJump = false;
    int NumberOfJumps = 0;
    [SerializeField] private Joystick MovementJoystick;
    [SerializeField] float Speed = 5f;
    [SerializeField] float JumpHeight = 30f;
    [SerializeField] private float HyperJumpDistance = 3f;
    Vector3 PlayerLoc { get => gameObject.transform.position; }
    void Start()
    {
        CharCont = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    void FixedUpdate()
    {
        Vector3 Direction = new Vector3(/*Joystickk.Horizontal*/Input.GetAxis("Horizontal") * HyperJump, 0, 0);
        Vector3 Velocity = Direction * Speed;
        if (CharCont.isGrounded)
        {
            Jump();
        }
        else
        {
            DoubleJump();
        }
        PressedJump = false;
        Velocity.y = yVelocity;
        CharCont.Move(Velocity * Time.deltaTime);
    }

    private void DoubleJump()
    {
        if (PressedJump == true && NumberOfJumps == 1) //double jump
        {
            NumberOfJumps = 2;
            if (NumberOfJumps == 2)
            {
                yVelocity = JumpHeight;
                HyperJump += HyperJumpDistance;
                NumberOfJumps = 0;
                PressedJump = false;
            }
        }
        yVelocity += Physics.gravity.y * 0.1f;
    }

    private void Jump()
    {
        HyperJump = 1;
        if (PressedJump == true)
        {
            NumberOfJumps = 1;
            yVelocity = JumpHeight;
            PressedJump = false;
        }
    }

    public void JumpButton()
    {
        PressedJump = true;
    }

}
