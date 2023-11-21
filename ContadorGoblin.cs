using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorGoblin : MonoBehaviour
{
    [SerializeField]
    private SpawnGoblin paladin;
    [SerializeField]
    private Estadisticas muerte;
    private int count;
    void Start()
    {
        muerte = GetComponent<Estadisticas>();
        paladin = FindAnyObjectByType<SpawnGoblin>();
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
