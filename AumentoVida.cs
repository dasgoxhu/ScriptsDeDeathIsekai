using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoVida : MonoBehaviour
{
    [SerializeField]
    private Estadisticas player;
    [SerializeField]
    private AudioSource sonido;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Estadisticas>();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "Player") 
        {
            player = GameObject.Find("Player").GetComponent<Estadisticas>();
            Debug.Log(other.gameObject.name);
            player.AumentarVida(10);
            Destroy(this.gameObject);
        }
    }
}
