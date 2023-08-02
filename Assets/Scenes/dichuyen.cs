using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
   public float traiPhai;
   public float lenXuong;
   public bool isFacingRight =true;
   public int tocDo =10;
   public Rigidbody2D rb;
   public Animator anin;
   private Vector3 originalScale;
    void Start()
    {
        originalScale=transform.localScale;
    }

 
    void Update()
    {
         traiPhai=Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocDo*traiPhai,rb.velocity.y);

        if(isFacingRight == true && traiPhai == -1)
        {
            transform.localScale = new Vector3(-1,1,1);
            isFacingRight =false;

          
        }
        if(isFacingRight == false && traiPhai == 1)
        {
            transform.localScale = new Vector3(1,1,1);
            isFacingRight = true;
     
        }

        lenXuong = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(0f, lenXuong, 0f) * tocDo * Time.deltaTime;
        transform.Translate(movement);

        anin.SetFloat("status",Mathf.Abs(traiPhai));
    }
}
