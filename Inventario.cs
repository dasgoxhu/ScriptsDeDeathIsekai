using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
    public GameObject InventarioA;
    public bool Pausa = false;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Pausa == false)
            {
                InventarioA.SetActive(true);
                Pausa = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Pausa == true)
            {
                Continuar();
            }
        }
    }
    public void Continuar()
    {
        InventarioA.SetActive(false);
        Pausa = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
   
}
