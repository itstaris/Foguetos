using System.Collections;
using System.Collections.Generic;
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
        // Jump
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
        }
        if (collision.gameObject.CompareTag("Power up"))
        {
            Debug.Log("colidiu com o power up");
            PowerUpIntangible();
        }
    }

    void PowerUpIntangible()
    {
        // Disable the collider so the player becomes intangible
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Reduce the sprite's alpha to 30%
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = 0.3f;
            sr.color = c;
        }

        Debug.Log("ligou o power up");
        StartCoroutine(PowerUpFinish());
    }

    IEnumerator PowerUpFinish()
    {
        yield return new WaitForSeconds(5f);

        // Re-enable the collider
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.enabled = true;
        }

        // Reset the sprite's alpha back to 100%
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = 1f;
            sr.color = c;
        }

        Debug.Log("desligou o power up");
    }
}
