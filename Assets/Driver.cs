using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    private float steerSpeed = 200f;
    private float driveSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float driveAmount = Input.GetAxis("Vertical") * driveSpeed * Time.deltaTime;

        transform.Rotate(0,0,-steerAmount); 
        transform.Translate(0, driveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Ouch!");
            driveSpeed = 15f;
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {

        if(trigger.gameObject.CompareTag("Boost"))
        {
            Debug.Log("Speed Boost!!!");
            driveSpeed = 30f;
        }
        
    }
}
