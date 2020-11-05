using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;    // Follow speed

    [HideInInspector]
    public bool hasTarget = false;  // do I have a target to move towards
    //[HideInInspector]
    public GameObject target;   // the target i want to get closer to 

    private float rotateH;
    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (target)
        {
            //get distance between me and my target
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // am I further than 2 units away
            if (distance < 5)
            {
                // I am over 2 units away
                follow(target.transform); // do a follow
            }
        }
        rotateH = Math.Sign(rb.velocity.x);
        if (rotateH != 0)
        {
            transform.localScale = new Vector3(rotateH, 1, 1);
        }
        animator.SetFloat("character_speed", rb.velocity.magnitude);

    }
 /*   
        // if anything starts to collide with me I will run this method
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Equals("PlayerObject"))
            {    // is the other object the player
                target = collision.gameObject;      // it is so set him as my target
                hasTarget = true;   // I have a target
            }
        }
*/
        // if something is no longer coliiding with me I will run this code
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.name.Equals("PlayerObject"))
            {
                target = null;
                hasTarget = false;
            }
        }
    
    private void follow(Transform target)
    {
        Vector2 vspeed = new Vector2((transform.position.x - target.position.x), (transform.position.y - target.position.y));
        Vector2 velocity = vspeed / vspeed.magnitude * speed;

        // add force to my rigid body to make me move
        rb.velocity = -velocity;
    }
}