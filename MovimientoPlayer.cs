using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public float VelMov = 5.0f;
    public float VelRot = 120.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float Fsalto = 8f;
    public bool Psaltar;
    public float velInicial;
    public float velAgachado;
    public bool EstoyAtacando;
    public bool AvanazaSolo;
    public float ImpulsoGolpe = 10f;
    public int fuerzaExtra = 0;
    public int velCorrer;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;
    public AudioSource pasos;
    public AudioSource Espada;
    private bool Hactivo;
    private bool Vactivo;

    private void Start()
    {
        Psaltar = true;
        anim = GetComponent<Animator>();
        velInicial = VelMov;
        velAgachado = VelMov * 0.4f;
    }

    void FixedUpdate()
    {
        if(!EstoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * VelRot, 0);
            transform.Translate(0, 0, y * Time.deltaTime * VelMov);
        }
        
        if(AvanazaSolo)
        {
            rb.velocity = transform.forward * ImpulsoGolpe;
        }
    }
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Horizontal"))
        {
            if (Vactivo == false)
            {
                Hactivo = true;
                pasos.Play();
            }
        }
        if(Input.GetButtonDown("Vertical"))
        {  
            if (Hactivo == false)
            {
                Vactivo = true;
                pasos.Play();
            }
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if(Vactivo==false)
            {
                pasos.Pause();
            }
            
        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo=false;
            if(Hactivo==false)
            {
                pasos.Pause();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && !estoyAgachado && Psaltar && !EstoyAtacando)

        {
            VelMov = velCorrer;
            if(y > 0)
            {
                x = Input.GetAxis("Horizontal") * 2;
                y = Input.GetAxis("Vertical") * 2;
                anim.SetBool("Correr", true);
            }
            else
            {
                anim.SetBool("Correr", false);
            }
        }
        else
        {
            anim.SetBool("Correr", false);
            if(estoyAgachado)
            {
                VelMov = velAgachado;
            }
            else if(Psaltar)
            {
                VelMov = velInicial;
            }
        }

        
        if(Input.GetMouseButtonDown(0) && Psaltar && !EstoyAtacando)
        {
            anim.SetTrigger("Golpe");
            Espada.Play();
            EstoyAtacando = true;

        }
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (Psaltar)
        {
            if(!EstoyAtacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("Saltar", true);
                    rb.AddForce(new Vector3(0, Fsalto, 0), ForceMode.Impulse);
                }
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("Agachado", true);
                    //VelMov = velAgachado;

                    cabeza.SetActive(true);
                    estoyAgachado = true;
                }
                else
                {
                    if(logicaCabeza.contDeColision <= 0)
                    {
                        anim.SetBool("Agachado", false);
                        //VelMov = velInicial;

                        cabeza.SetActive (false);
                        estoyAgachado = false;
                    }
                }
            }
            anim.SetBool("TocarSuelo", true);
        }
        else
        {
            
            EsCayendo();
        }
    }

    private object Vector3(float x, float v, float y)
    {
        throw new NotImplementedException();
    }

    public void EsCayendo()
    {
        anim.SetBool("TocarSuelo", false);
        anim.SetBool("Saltar", false);

    }

    public void DejarGolpe()
    {
        EstoyAtacando = false;
    }

    public void DejarAvanzarSolo()
    {
        AvanazaSolo = true;
    }

    public void DejoAvanzar()
    {
        AvanazaSolo = false;
    }
}
