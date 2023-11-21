using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinGame : MonoBehaviour
{
    public GameObject ObjWinGame;
    public bool Pausa = false;
    void Start()
    {

    }
    void Update()
    {
            if (Pausa == true)
            {
                ObjWinGame.SetActive(true);
                Pausa = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
           
    }
   

    public void IrMenuP(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
        ObjWinGame.SetActive(false);
    }
    public void SalirGame()
    {
        Application.Quit();
    }
}
