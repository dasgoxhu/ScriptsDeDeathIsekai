using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoblin : MonoBehaviour
{
    [SerializeField]
    private float time;
    public GameObject Goblin;
    [SerializeField]
    private int countMax;
    public int count;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * 1;
        if (count < Mathf.Round(countMax/3) && time < 1)
        {
            time = 120;
            for (int i = 0; i < countMax; i++) 
            {
                instaciar();
            }
            
        }
    }

    void instaciar()
    {
        Instantiate(Goblin, transform);
        count++;
    }

    void murio(int contador)
    {
        count -= contador;
    }
}
