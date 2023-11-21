using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDano : MonoBehaviour
{
   
        [SerializeField]
        private Dano1 player;
        [SerializeField]
        private AudioSource sonido;
    private void Start()
    {
        player = GameObject.Find("EspadaPlayer").GetComponent<Dano1>();
    }

    private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.name == "Player")
            {
                player = GameObject.Find("EspadaPlayer").GetComponent<Dano1>();
                Debug.Log(other.gameObject.name);    
                player.dano += 10;
                this.gameObject.SetActive(false);
                Invoke("Destroy", 5);
            }
        }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
