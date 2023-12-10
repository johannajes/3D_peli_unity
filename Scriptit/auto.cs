using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
 
    void Update () {
         
    }
    void OnMouseDown(){
        // this object was clicked - do something
        playClip();
        rosvo.instance.distance=false;
        rosvo2.instance.distance=false;
        rosvo3.instance.distance=false;
    }   
    
    public void playClip(){
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = false;
    }
    private void OnTriggerEnter(Collider collision){
        ProcessCollision(collision.gameObject);
    }
    private void OnCollisionEnter(Collision collision){
        ProcessCollision(collision.gameObject);
    }

    void ProcessCollision(GameObject collider) {
        if (collider.CompareTag("Player")) {
            //this rigidbody hit the player
            Debug.Log("Voitto.");
        } 
    }
}
 

