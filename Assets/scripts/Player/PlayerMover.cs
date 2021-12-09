using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/**
 * This component moves its object when the player clicks the arrow keys and use mouse.
 */
public class PlayerMover : MonoBehaviourPun
{
    [Tooltip("Speed of movement")] [SerializeField]
    float speed = 4f;

    [SerializeField] float sprintSpeed = 8f;
    private CharacterController controller;

    public Camera PlayerSee;

    private KeyCode sprint;
    private float currentSpeed;
    private bool canRotate;
    private bool canMove;
    public static GameObject LocalPlayerInstance;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerMover.LocalPlayerInstance = this.gameObject;
        }

        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        canRotate = true;
        canMove = true;
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        if (PlayerSee.enabled == false) //on only player camera 
            PlayerSee.enabled = true;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

        controller.SimpleMove(Vector3.forward * 0); //move player gravity
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical"); // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");
        
        if (canRotate)
            transform.Rotate(0, rotX, 0);

        Vector3 movementVector = new Vector3(horizontal, 0, vertical) * currentSpeed * Time.deltaTime;
        if (canMove)
            controller.Move(transform.rotation * movementVector);
        
        if (canRotate)
            PlayerSee.transform.Rotate(-rotY * currentSpeed, 0, 0);
    }

    public void SetCanRotate(bool b)
    {
        Debug.Log("freeze rotate" + b);
        canRotate = b;
    }

    public void SetCanMove(bool b)
    {
        canMove = b;
    }

    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    public float getSpeed()
    {
        return this.speed;
    }
}