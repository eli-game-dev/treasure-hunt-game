using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class interact : MonoBehaviourPun
{
    
    [SerializeField] string triggeringTag;
    [SerializeField] private String clueString;
    [SerializeField] private TextMeshProUGUI clueText;
    public GameObject CanvasQuestion;
    public GameObject textPreesToSeeQuestion;
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
            textPreesToSeeQuestion.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other )
    {
        if (other.tag == triggeringTag && other.GetComponent<PhotonView>().IsMine)
        {
            if (answered)
            {
                objectAnswered = true;
                answered = false;
                clueText.text = clueString;
            }
            if (Input.GetKey(KeyCode.E)&&!objectAnswered)
            {
                other.GetComponent<PlayerMover>().SetCanRotate(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                textPreesToSeeQuestion.SetActive(false);
                CanvasQuestion.SetActive(true); 
            }
            Debug.Log(objectAnswered);  
            if (objectAnswered) 
            {
                Debug.Log("answered");  
                textPreesToSeeQuestion.SetActive(false);
                other.GetComponent<PlayerMover>().SetCanRotate(true);
                CanvasQuestion.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;   
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggeringTag && other.GetComponent<PhotonView>().IsMine)
        {
            textPreesToSeeQuestion.SetActive(false);
            other.GetComponent<PlayerMover>().SetCanRotate(true);
            CanvasQuestion.SetActive(false);
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
