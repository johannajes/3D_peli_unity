using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liike : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float airMultiplier;
    public float jumpForce;
    public float jumpCoolDown;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisGround;
    bool grounded;

    

    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(grounded);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f+0.2f, whatisGround);

        PlayerInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate() {
        MovePlayer();
    }

    private void PlayerInput() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //if(Input.GetKey(jumpKey) && readyToJump && grounded) {
        if(Input.GetKey(jumpKey) && readyToJump && grounded) {
            Debug.Log("Hyppy kutsu");
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    private void MovePlayer() {
        moveDirection = orientation.forward*verticalInput+orientation.right*horizontalInput;
        if(grounded)
            rb.AddForce(moveDirection.normalized*moveSpeed*10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized*moveSpeed*10f*airMultiplier, ForceMode.Force);
    }

    

    private void SpeedControl() {
        Vector3 flatVel = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        if (flatVel.magnitude > moveSpeed) {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);
        } 
    }
    private void Jump() {
            Debug.Log("Hyppy");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump() {
        readyToJump = true;
    }
}
