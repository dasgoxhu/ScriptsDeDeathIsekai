using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPaladin: MonoBehaviour
{
    [SerializeField]
    private SpawnPaladin paladin;
    [SerializeField]
    private Estadisticas muerte;
    private int count;
     void Start()
    {
        muerte = GetComponent<Estadisticas>();
        paladin = FindAnyObjectByType<SpawnPaladin>();
    }

    void Update()
    {
        if (muerte.vida < 1) 
        {
            count = muerte.muerte();
            paladin.count -= count;
        }
    }
}
