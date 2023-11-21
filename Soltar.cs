using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soltar : MonoBehaviour
{
    public GameObject Arma;
    public GameObject Pocion;
    public int arma;
    public int pocion;
 

    public void SoltarArma(Transform punto) 
    {
        arma += 1;
        Instantiate(Arma, punto.position, transform.rotation);
    }

    public void SoltarPocion(Transform punto) 
    {
        pocion += 1;
        Instantiate(Pocion, punto.position, transform.rotation);
    }
}
