using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rosvo3 : MonoBehaviour
{
    public static rosvo3 instance;

    private GameObject wayPoint;
    private GameObject wayPoint2;
    private Vector3 wayPointPos;
    private Vector3 myPosition;
    int range = 20;
    public bool distance = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 2.0f;
    private void Awake() {
        instance = this;
    }
    void Start()
    {
        wayPoint = GameObject.Find("Pelaaja");
        wayPoint2 = GameObject.Find("Rosvo3");
    }

    // Update is called once per frame
    void Update()
    {
        myPosition = new Vector3(wayPoint2.transform.position.x, wayPoint2.transform.position.y, wayPoint2.transform.position.z);
        wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        if(distance == false){
            CheckDistance();
        } else {
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            speed = 4.0f;
        }
    }
    void CheckDistance(){
        if(Vector3.Distance(myPosition, wayPointPos) < range){
            playClip();
            distance = true;  
        }
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
            Debug.Log("Häviö");
        }
    }
    public void playClip(){
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = false;
    }
}
