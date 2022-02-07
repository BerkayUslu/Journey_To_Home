using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //States
    string IDLING = "IDLING";
    string SKIPPING = "SKIPPING";
    string CLIMBING = "CLIMBING";
    string FALLING = "FALLING";
    string DUCKING = "DUCKING";
    string JUMPING = "JUMPING";
    string HURT = "HURT";

    //cache
    Rigidbody2D rigidbody;
    Vector2 moveInput;
    [SerializeField]int jumpsInput = 200;
    [SerializeField] int movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Skipping();

    }

    private void Skipping()
    {
        rigidbody.velocity = moveInput * movementSpeed * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        rigidbody.AddForce(new Vector2(0, jumpsInput));
    }

}
