using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private CapsuleCollider2D myCapsuleCollider;
    [SerializeField] private BoxCollider2D playerFeetCollider;
    [SerializeField] private float enemySpeed = 1f;

    void Awake()
    {
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        destroyObjectIfPlayerFeetTouches();
        Walk();
    }

    private void destroyObjectIfPlayerFeetTouches()
    {
        if (playerFeetCollider == null) {return;}
        if (myCapsuleCollider.IsTouching(playerFeetCollider))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        flipEnemypSprite();
    }

    private void flipEnemypSprite()
    {
        gameObject.transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), 1, 1);
    }

    private void Walk()
    {
        {
            /*if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                flipEnemySprite();
            }*/
            Vector2 currentEnemySpeed = new Vector2(-transform.localScale.x*enemySpeed, 0);
            myRigidbody.velocity = currentEnemySpeed;
        }
    }
}
