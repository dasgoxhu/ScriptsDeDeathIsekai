using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public GameObject ObjMuerte;
    public bool Pausa = false;
    void Start()
    {

    }
    void Update()
    {
            if (Pausa == true)
            {
                ObjMuerte.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
    }

    public void IrMenuP(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
        ObjMuerte.SetActive(false);
    }
    public void SalirGame()
    {
        Application.Quit();
    }
}
