using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class player : MonoBehaviour

{
    public int jump_velocity;  
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            //pulo
         if (Input.GetKeyDown(KeyCode.Space))
         {
            Jump();
         }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
            Debug.Log("colidiu");
        }
        //else (collision.gameObject.CompareTag("Power up"))
       // {

        //}
    }
}
