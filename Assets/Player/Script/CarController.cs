using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   float steerSpeed = 200f;
   float moveSpeed = 20f;
   float slowSpeed = 15f;
   float boostSpeed = 30f;

 
    // Update is called once per frame
    void Update()
    {
       
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float accelerationAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(-accelerationAmount , 0, 0) ;
        transform.Rotate(0f, 0f, -steerAmount);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            Debug.Log("Boost" + moveSpeed.ToString());
            moveSpeed = boostSpeed;
            Debug.Log("Boost" + moveSpeed.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bump")
        {
            Debug.Log("Slow" + moveSpeed.ToString());
            moveSpeed = slowSpeed;
            Debug.Log("Slow" + moveSpeed.ToString());
        }
    }
}
