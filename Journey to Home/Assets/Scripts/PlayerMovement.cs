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
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    Vector2 moveInput;

    [Header("Movement")]
    [SerializeField] float playerVelocityConstant = 5f;
    [SerializeField] float jumpVelocityConstant = 5f;
    [Header("Collider")]
    [Header("State")]
    [SerializeField] string playerState;
    [SerializeField] string prvPlayerState;


    // Start is called before the first frame update
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        prvPlayerState = IDLING;
        CheckPlayerState();
    }

    //Controls and deciders player's state
    private void CheckPlayerState()
    {
        prvPlayerState = playerState;
        if (YPositionGetsLower())
        {
            playerState = FALLING;
        }
        else if (!myRigidbody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerState = JUMPING;
        }else if (moveInput.x != 0)
        {
            playerState = SKIPPING;
        }
        else {
            playerState = IDLING;
        }
        
    }

    private bool YPositionGetsLower()
    {
        return myRigidbody.velocity.y < -0.01;
    }

    // Update is called once per frame
    void Update()
    {
        Skipping();
        CheckPlayerState();
        FlipSprite();
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if(prvPlayerState != playerState)
        {
            myAnimator.SetBool(prvPlayerState, false);
        }
        myAnimator.SetBool(playerState, true);
    }

    private void FlipSprite()
    {
        //epsilon is smallest value of float 
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector3(Mathf.Sign(myRigidbody.velocity.x), 1, 1);
        }
    }

    private void Skipping()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerVelocityConstant, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if ((playerState != JUMPING) && (playerState != FALLING))
        {
            Vector2 jumpVelocity = new Vector2(0, 1) * jumpVelocityConstant;
            myRigidbody.velocity = jumpVelocity;
        }
    }


}
