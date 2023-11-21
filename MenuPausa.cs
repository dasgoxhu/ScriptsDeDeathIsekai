using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjPausa;
    public bool Pausa = false;
    public GameObject MenuSalir;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjPausa.SetActive(true);
                Pausa = true;
                Time.timeScale = 0;
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
        ObjPausa.SetActive(false);
        if(MenuSalir != null) 
        {
            MenuSalir.SetActive(false);
        }
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IrMenuP(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
        ObjPausa.SetActive(false);
    }
    public void SalirGame()
    {
        Application.Quit();
    }
}
