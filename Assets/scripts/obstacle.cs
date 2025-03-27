using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public static float velocity; // Shared velocity for all obstacles
    public float initialVelocity;  // Starting velocity (used to set the starting value)
    public float velocityIncreaseRate; // Rate at which the velocity increases

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the shared velocity with the initial value
        if (velocity == 0)  // Ensure that the velocity only gets set once
        {
            velocity = initialVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the shared velocity over time
        velocity += velocityIncreaseRate * Time.deltaTime;

        // Move the obstacle
        Vector3 movement = new Vector3(1, 0, 0);
        transform.Translate(movement * velocity * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Debug.Log("colidiu");
        }
    }
}
