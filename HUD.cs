using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Text Salud;
    public Text Da�o;
    public Estadisticas player;
    public Dano1 dano;
    float numVida;
    float numDa�o;
    void Start()
    {
        numVida = 90;
    }
    void Update()
    {
        numVida = player.vida;
        numDa�o = dano.dano;
        Salud.text = "X" + numVida.ToString();
        Da�o.text = "X" + numDa�o.ToString();
    }

}
