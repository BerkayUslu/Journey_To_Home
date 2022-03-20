using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    [SerializeField] private BoxCollider2D playerFeetCollider;
    [SerializeField] private float intervalTime = 4;
    
    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(Walk());
    }

    private void Update()
    {
        if (myBoxCollider.IsTouching(playerFeetCollider))
        {
            Destroy(gameObject);
        }
    }

    private void spriteDirection(int directionValue)
    {
        Vector3 scaleValue = new Vector3(-directionValue, 1, 1);
        transform.localScale = scaleValue;
    }

    IEnumerator Walk()
    {
        int directionDecisionValue = -1;
        while (true)
        {
            Vector2 enemySpeed = new Vector2(directionDecisionValue, 0);
            myRigidbody.velocity = enemySpeed;
            spriteDirection(directionDecisionValue);
            yield return new WaitForSeconds(intervalTime);
            directionDecisionValue *= -1;
        }
    }
}
