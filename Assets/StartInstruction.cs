using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInstruction : MonoBehaviour
{
    public GameObject InstructionUI;
    [SerializeField]
    private int timeObjectActive;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(activeInstruction());
    }

    private IEnumerator activeInstruction()
    {
        InstructionUI.SetActive(true);
        yield return new WaitForSeconds(timeObjectActive);
        InstructionUI.SetActive(false);
    }
}
