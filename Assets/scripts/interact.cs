using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class interact : MonoBehaviourPun
{
    
    [SerializeField] string triggeringTag;
    public GameObject Canvas;
    public GameObject text;
    private static bool answered;
    private bool objectAnswered;

    // Start is called before the first frame update
    void Start()
    {
        answered = false;
        objectAnswered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == triggeringTag && other.GetComponent<PhotonView>().IsMine)
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other )
    {
        if (other.tag == triggeringTag && other.GetComponent<PhotonView>().IsMine)
        {
            if (answered)
            {
                Debug.Log("test");  
                objectAnswered = true;
                answered = false;
            }
            if (Input.GetKey(KeyCode.E)&&!objectAnswered)
            {
                other.GetComponent<KeyboardMover>().SetCanRotate(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.SetActive(false);
                Canvas.SetActive(true); 
            }
            Debug.Log(objectAnswered);  
            if (objectAnswered) 
            {
                Debug.Log("answered");  
                text.SetActive(false);
                other.GetComponent<KeyboardMover>().SetCanRotate(true);
                Canvas.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;   
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggeringTag && other.GetComponent<PhotonView>().IsMine)
        {
            text.SetActive(false);
            other.GetComponent<KeyboardMover>().SetCanRotate(true);
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    public void setAnswred(bool b)
    {
        Debug.Log("answered = true");  
        answered = b;
        Debug.Log(answered);  
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("enter");
    //     if (other.gameObject.tag == triggeringTag)
    //     {
    //         Debug.Log("enter2");
    //         Canvas.SetActive(true);
    //     }
    // }



    // Update is called once per frame
    void Update()
    {
        
    }
}
