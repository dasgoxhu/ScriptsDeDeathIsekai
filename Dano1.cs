using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano1 : MonoBehaviour
{
    private Estadisticas enemigo;
    public float dano;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo") 
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
