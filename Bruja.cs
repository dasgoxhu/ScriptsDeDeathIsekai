using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bruja : MonoBehaviour
{
    [SerializeField]  
    private Transform Enemigo;
    [SerializeField]
    private GameObject bolafuego;
    private Animator animator;
    [SerializeField]
    private GameObject Slaves;
    [SerializeField]
    private int cantSlaves;
    [SerializeField]
    private Vector3[] Tp;
    [SerializeField]
    private Transform aparicion;
    private float tiempoinvocacion;
    private float tiempoBolaFuego;
    private float tiempoTeleportacion;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("x", 0);
        animator.SetFloat("y", 0);
        cantSlaves = 0;
        tiempoinvocacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoinvocacion += Time.deltaTime * 1;
        tiempoBolaFuego += Time.deltaTime * 1;
        tiempoTeleportacion += Time.deltaTime * 1;
        if (Enemigo != null) 
        {
            transform.LookAt(Enemigo);
            if (cantSlaves <= 3 && tiempoinvocacion > 10)
            {
                instaciar();
                
            }
            else if (tiempoBolaFuego>3)
            {
                BolaFuego();
                tiempoBolaFuego =0;
            }
            else if(tiempoTeleportacion>8)
            {
                Teleportacion();
                tiempoTeleportacion = 0;
            }
        }
        
    }
    void instaciar()
    {
        Debug.Log("Invocar" + tiempoinvocacion);
        animator.SetFloat("x", 0);
        animator.SetFloat("y", 1);
        tiempoinvocacion = 0;
        Instantiate(Slaves, aparicion);
        cantSlaves++;
    }

    void Teleportacion() 
    {
        animator.SetFloat("x", -1);
        animator.SetFloat("y", 0);
        int indice = Random.Range(0, Tp.Length);
        transform.position = Tp[indice];
    }

    void BolaFuego() 
    {
        animator.SetFloat("x", 0);
        animator.SetFloat("y", -1);
        Instantiate(bolafuego,transform.position,transform.rotation).AddComponent<BolaDeFuego>().enemigo = Enemigo;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Aliado") 
        {
            Enemigo = other.transform;
        }
    }
}
