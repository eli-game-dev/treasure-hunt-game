using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    
    [SerializeField] string triggeringTag;
    public GameObject Canvas;
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == triggeringTag)
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == triggeringTag)
        {
            if (Input.GetKey(KeyCode.E))
            {
                other.GetComponent<KeyboardMover>().SetCanRotate(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                text.SetActive(false);
                Debug.Log("enter2");
                Canvas.SetActive(true); 
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == triggeringTag)
        {
            other.GetComponent<KeyboardMover>().SetCanRotate(true);
            Canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
