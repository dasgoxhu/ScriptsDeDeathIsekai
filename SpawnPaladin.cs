using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaladin : MonoBehaviour
{
    [SerializeField]
    private float time;
    public GameObject Paladin;
    [SerializeField]
    private int countMax;
    public int count;
    void Start()
    {
        count = 0;
        for (int i = 0; i < countMax; i++) 
        {
            instaciar();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 1;
        if(count<countMax && time>120) 
        {
            time = 0;
            instaciar();
        }
    }

    void instaciar() 
    {
      Instantiate(Paladin,transform);
      count++;
    }

    void murio(int contador) 
    {
        count-= contador;
    }
}
