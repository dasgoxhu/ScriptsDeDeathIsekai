using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Estadisticas : MonoBehaviour
{
    
    public float vidaMax;
    public float vida;
    public bool vidaFaltante;
    float tiempo;
    float tiempoRecuperacion;
    public Soltar drop;
    private void Start()
    {
        vida = vidaMax;
    }

    void Update()
    {
        tiempoRecuperacion += Time.deltaTime * 1;
        if(this.gameObject.name == "Player" && tiempoRecuperacion>10)
        {
            RecuperarVida();
            tiempoRecuperacion = 0;
        }
        tiempo += Time.deltaTime * 1;
        if ((vidaMax * 0.9)>vida) 
        {
            vidaFaltante = true;
        }
        else 
        {
            vidaFaltante = false;
        }
    }

    public void ReducirVida(float dano) 
    {
        vida -= dano;
    }
    public void AumentarVida(float aumento) 
    {
        vidaMax += aumento;
    }

    public void RecuperarVida() 
    {
        if (vidaMax > vida) 
        {
            vida += 10;
            tiempo = 0;
        }
        
    }

    public int muerte() 
    {
        if (drop != null) 
        {
            int suerte = Random.Range(0,10);
            if(suerte < 2)
            {
                Debug.Log("Mala Suerte");
            }
            else if(suerte < 5) 
            {
                Debug.Log("Vida");
                drop.SoltarPocion(transform);
            }
            else if(suerte > 5)
            {
                Debug.Log("Arma");
                drop.SoltarArma(transform);
            }
        }
        Destroy(this.gameObject);
        return 1;
    }
}
