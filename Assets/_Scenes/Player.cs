using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector3 moveInput;
    public Animator animator;
    public SpriteRenderer charectorSR;
    
   
    void Start()
    {
        
    }

 
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("status", moveInput.sqrMagnitude);

        if(moveInput.x != 0)
        {
            if (moveInput.x > 0)
               charectorSR.transform.localScale = new Vector3(1, 1, 0);
            else
               charectorSR.transform.localScale = new Vector3(-1, 1, 0);
        }
    }
}
