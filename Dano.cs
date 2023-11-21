using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    private Estadisticas enemigo;
    public float dano;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Aliado") 
        {
           enemigo = other.GetComponent<Estadisticas>();
           enemigo.ReducirVida(dano);
        }
        else
        {
            enemigo=null;
        }
    }
}
