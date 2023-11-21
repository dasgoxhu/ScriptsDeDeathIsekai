using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAtaque : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public bool TengoEnemigo;
    public Vector3 patrulla;
    public Transform enemigo;
    public Transform Lugar;
    private float time;
    void Start()
    {
        Lugar = GameObject.Find("ZonaAtaque").transform;
        patrulla = Lugar.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetFloat("X", 1);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (TengoEnemigo && enemigo != null) 
        {
            Debug.DrawLine(transform.position, enemigo.position, Color.red);
            Atacar();
        }
        else 
        {
            Patrullar();
        }
    }

    private void Atacar()
    {
        float distancia = Vector3.Distance(transform.position,enemigo.position);
        if (distancia > 3.2f) 
        {
            agent.isStopped = false;
            animator.SetFloat("Y", 0);
            animator.SetFloat ("X", -1);
            agent.speed = 3.5f;
            agent.destination = enemigo.position;
        }
        else 
        {
            agent.isStopped = true;
            animator.SetFloat("Y", 1);
            animator.SetFloat("X", 0);
            transform.LookAt(enemigo.position);
        }
            
    }

    void Patrullar() 
    {
        time += Time.deltaTime * 1;
        if (time > 5) 
        {
            agent.isStopped = false;
            animator.SetFloat("Y",0);
            animator.SetFloat("X", 1);
            agent.speed = 2.5f;
            if (agent.remainingDistance < 3f) 
            {
                agent.destination = rutanueva();
            }
            
        }
        
    }

    Vector3 rutanueva() 
    {
            Vector3 Ruta = new Vector3(patrulla.x + Random.Range(-35,35),transform.position.y, patrulla.z + Random.Range( - 35,  + 35));

            return Ruta;   
    }
}
