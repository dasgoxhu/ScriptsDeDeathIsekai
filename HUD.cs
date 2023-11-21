using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Text Salud;
    public Text Daño;
    public Estadisticas player;
    public Dano1 dano;
    float numVida;
    float numDaño;
    void Start()
    {
        numVida = 90;
    }
    void Update()
    {
        numVida = player.vida;
        numDaño = dano.dano;
        Salud.text = "X" + numVida.ToString();
        Daño.text = "X" + numDaño.ToString();
    }

}
