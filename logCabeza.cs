using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCabeza : MonoBehaviour
{
    public int contDeColision;
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "NPC")
        {
            contDeColision++;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "NPC")
        {
            contDeColision--;
        }
    }
}
