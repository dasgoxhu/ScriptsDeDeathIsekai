using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaCaer : MonoBehaviour
{
    public MovimientoPlayer Mp;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Vision")
        {
            Mp.Psaltar = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Vision")
            Mp.Psaltar = false;
    }

}
