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

    //
    Rigidbody2D rigidbody;
    Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
     

    }

     OnMove(InputValue value)
    {

    }

}
