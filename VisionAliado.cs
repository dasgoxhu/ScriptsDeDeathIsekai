using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAliado : MonoBehaviour
{
    public float AnguloVision;
    public Paladin paladin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Vector3 Direccion = collision.transform.position - transform.position;
            float Angulo = (Vector3.Angle(Direccion, transform.forward));

            if (Angulo >= -AnguloVision && Angulo <= AnguloVision)
            {
                paladin.combate = true;
                paladin.Atacar(collision.transform);
            }
            else
            {
                paladin.combate = false;
            }

        }
    }
}
