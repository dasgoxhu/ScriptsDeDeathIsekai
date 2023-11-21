using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEnemigoAtaque : MonoBehaviour
{
    public float AnguloVision;
    public GoblinAtaque goblin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            Vector3 Direccion = collision.transform.position - transform.position;
            float Angulo = (Vector3.Angle(Direccion, transform.forward));

            if (Angulo >= -AnguloVision && Angulo <= AnguloVision)
            {
                goblin.TengoEnemigo = true;
                goblin.enemigo = collision.transform;  
            }
            else
            {
                goblin.TengoEnemigo = false;
            }

        }
    }
}
