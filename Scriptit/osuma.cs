using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osuma : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision){
        ProcessCollision(collision.gameObject);
    }
    private void OnCollisionEnter(Collision collision){
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider) {
        if (collider.CompareTag("Rosvo")) {
            //this rigidbody hit the player
            Debug.Log("Osuma pelaaja ja rosvo.");
        } 
        else if (collider.CompareTag("Car")) {
            //this rigidbody hit the player
            Debug.Log("Osuma pelaaja ja auto.");
        }
    }
}
