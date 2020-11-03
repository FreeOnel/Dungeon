using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    private float rotateH;
    [SerializeField] public float moveSpeed = 5.0F;
    [SerializeField] public float sprintMultiplier = 2F;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       moveH = Input.GetAxisRaw("Horizontal")*moveSpeed; 
       moveV = Input.GetAxisRaw("Vertical")*moveSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            moveH *= sprintMultiplier;
            moveV *= sprintMultiplier;
        }

        rotateH = Math.Sign(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") != 0) {
            transform.localScale = new Vector3(rotateH, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }

}
