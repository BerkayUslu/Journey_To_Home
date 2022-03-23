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
    [SerializeField] private float intervalTime = 4;
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
        if (myCapsuleCollider.IsTouching(playerFeetCollider))
        {
            Destroy(gameObject);
        }
    }
    
    private void Walk()
    {
        {
            if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                gameObject.transform.localScale = new Vector3(transform.localScale.x*-1,1,1);
            }
            Vector2 currentEnemySpeed = new Vector2(-transform.localScale.x*enemySpeed, 0);
            myRigidbody.velocity = currentEnemySpeed;
        }
    }
}
