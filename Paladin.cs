using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Paladin : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 Descanso;
    public Estadisticas vida;
    private Animator animator;
    private Vector3 patrullar;
    public bool conversacion;
    public bool combate;
    void Start()
    {
        patrullar = transform.position;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        vida = GetComponent<Estadisticas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (combate) 
        {

        }
        else 
        {
            if (vida.vidaFaltante) 
            {
                RecuperarVida();
            }
            else 
            {
                
                zonaPatrulla(); 
            }
        }
    }

    void zonaPatrulla() 
    {
        if (agent.remainingDistance < 2f) 
        {
            agent.isStopped = false;
            agent.destination = new Vector3(patrullar.x + Random.Range(-15,15),patrullar.y, patrullar.z + Random.Range(-15, 15));
            animator.SetFloat("X", 1);
            animator.SetFloat("Y", 0);
        }
    }

    public void Atacar(Transform enemigo) 
    {
        float Distancia = Vector3.Distance(transform.position,enemigo.position);
        if (Distancia > 2.2f) 
        {
            agent.isStopped = false;
            agent.destination = enemigo.position;
            animator.SetFloat("X", 1);
            animator.SetFloat("Y", 0);
        }
        else 
        {
            agent.isStopped = true;
            animator.SetFloat("Y", 1);
            animator.SetFloat("X", 0);
            transform.LookAt(enemigo.position);
        }
    }

    void hablar(Transform Aliado) 
    {
        
    }

    void RecuperarVida() 
    {
        float distancia = Vector3.Distance(transform.position,Descanso);
        if (distancia > 2) 
        {
            agent.isStopped = false;
            agent.destination = Descanso;
            animator.SetFloat("X",1);
            animator.SetFloat("Y",0);
        }
        else 
        {
            agent.isStopped = true;
            animator.SetFloat("X",-1);
            animator.SetFloat("Y",0);
            vida.RecuperarVida();
        }
    }
}
