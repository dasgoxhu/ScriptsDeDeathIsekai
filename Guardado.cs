using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.IO;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Guardado : MonoBehaviour
{
    string ArchivoJugando;
    string apodoAux;
    string apodoAux1;
    string contrasenaaux;
    private string[] JugadorG; 
    private DatosGuardado aux = new DatosGuardado() { apodo = ""};
    private string Archivo;
    public bool verficar;
    private string ApodoPref;
    public GameObject MenuMuerte;
    public GameObject MenuWinGame;
    public GameObject MenuLogin;
    public GameObject MenuRegistro;
    public GameObject MenuInicial;
    public Estadisticas jugador;
    public Estadisticas boss;
    public Dano1 dano;
    public Text comunicado;
    public Text Verificar;
    public MenuMuerte muerte;
    public MenuWinGame WinGame;
    public Text validacionResgistro;

    public float tiempo;
    private void Start()
    {
        verficar = false;
    }

    private void Update()
    {
        tiempo += Time.deltaTime * 1;
        if (comunicado != null && tiempo > 2)
        {
            GetAllApodos();
        }
        
        if (jugador != null)
        {
            if(ApodoPref == null) 
            {
                ApodoPref = PlayerPrefs.GetString(ApodoPref);
                
            }
            Debug.Log("Apodo del json: " + ApodoPref);
            if (jugador.vida<1) 
            {
                GuardarAtributos(jugador.vidaMax + "",dano.dano + "", " Perdiste el Juego");
                muerte.Pausa = true;
                Debug.Log(jugador.vida);
                MenuMuerte.SetActive(true);
                
            }
        }
        
        if(boss != null) 
        {
            if (boss.vida < 1) 
            { 
                GuardarAtributos(jugador.vidaMax + "", dano.dano + "", "Ganaste el juego");
                MenuWinGame.SetActive(true);
                WinGame.Pausa = true;
                Debug.Log(WinGame.Pausa);
                
            }
        }
    }

    public void salir() 
    {
        GuardarAtributos(jugador.vidaMax + "", dano.dano + "", "No Termino el Juego");
    }

    public void verificar() 
    {
        if (File.Exists(Archivo))
        {
            string contenido = File.ReadAllText(Archivo);
            aux = JsonUtility.FromJson<DatosGuardado>(contenido);
            JugadorG = aux.apodo.Split(',');
            for (int i = 0; i < JugadorG.Length; i++)
            {

                if (JugadorG[i] != "") 
                {
                    ArchivoJugando = Application.dataPath + "/" + JugadorG[i] + ".json";
                    contenido = File.ReadAllText(ArchivoJugando);
                    aux = JsonUtility.FromJson<DatosGuardado>(contenido);
                    Debug.Log(aux.correo + apodoAux1);
                    Debug.Log(aux.contrasena + contrasenaaux);
                    if (aux.correo == apodoAux1 && aux.contrasena == contrasenaaux)
                    {
                    Debug.Log("Existe usuario");
                        apodoAux = aux.apodo;
                        Reescribir();
                        break;
                    }
                }
                
            }
                Verificar.text = "Usuario o Contraseña no coincide";
        }
        else 
        {
            MenuRegistro.SetActive(true);
            MenuLogin.SetActive(false);
        }
    }
    private void Awake()
    {
        Archivo = Application.dataPath + "/ListaDeUsuarios.json";

    }

    public void Reescribir() 
    {
        Debug.Log(apodoAux);
        ArchivoJugando = Application.dataPath + "/" + apodoAux + ".json";
        aux.apodo = apodoAux;
        Save();
        MenuInicial.SetActive(true);
        MenuLogin.SetActive(false);
        Debug.Log("Sobre Escribe..." + ArchivoJugando);
        
    }
    
    private void Save() 
    {
        PlayerPrefs.SetString(ApodoPref, apodoAux);
        PlayerPrefs.Save();
    }

    private bool verificarg(string apodo, string correo)
    {
        if (File.Exists(Archivo))
        {
            string contenido = File.ReadAllText(Archivo);
            aux = JsonUtility.FromJson<DatosGuardado>(contenido);
            JugadorG = aux.apodo.Split(',');
            for (int i = 0; i < JugadorG.Length; i++)
            {
                if (JugadorG[i] != "") 
                {
                    Debug.Log("Verificando");
                    ArchivoJugando = Application.dataPath + "/" + JugadorG[i] + ".json";
                    contenido = File.ReadAllText(ArchivoJugando);
                    aux = JsonUtility.FromJson<DatosGuardado>(contenido);
                    if (aux.apodo == apodoAux)
                    {
                        Debug.Log("Existe usuario");
                        validacionResgistro.text = "Existe Usuario";
                        return false;
                    }
                    if ( aux.correo == apodoAux1) 
                    {
                        validacionResgistro.text = "Ya esta usado ese correo";
                        return false;
                    }
                }
                    
            }
            
        }
        Debug.Log(aux.apodo);
        return true;
    }
    public void GuadarNuevo()
    {
        if (!File.Exists(Archivo)) 
        {
            string cadenaJson = JsonUtility.ToJson(aux, true);
            File.WriteAllText(Archivo, cadenaJson);
            Debug.Log("Guarda Con Archivo..." + Archivo);
        }

        if (verificarg(apodoAux, apodoAux1)) 
        {
            string contenido = File.ReadAllText(Archivo);
            aux = JsonUtility.FromJson<DatosGuardado>(contenido);
            Debug.Log("Antes" + aux.apodo);
            Debug.Log("Porfis");   
            //ListasDeusuarios
            ArchivoJugando = Application.dataPath + "/" + apodoAux +".json";
            aux.apodo +=apodoAux + ",";
            aux.correo += apodoAux1 + ",";
            Debug.Log("Lista:" + aux.apodo);
            string cadenaJson = JsonUtility.ToJson(aux, true);
            File.WriteAllText(Archivo, cadenaJson);
            Debug.Log("Guarda Con Archivo..." + Archivo);
            //Usuario
            aux.correo = apodoAux1;
            aux.apodo = apodoAux;
            aux.contrasena = contrasenaaux;
            cadenaJson = JsonUtility.ToJson(aux, true);
            File.WriteAllText(ArchivoJugando, cadenaJson);
            Save();
            MenuInicial.SetActive(true);
            MenuRegistro.SetActive(false);
        } 
        
    }

    public void GuardarAtributos(string vida, string dano, string boss) 
    {
        string contenido;
        ArchivoJugando = Application.dataPath + "/" + ApodoPref + ".json";
        Debug.Log(ArchivoJugando);
        contenido = File.ReadAllText(ArchivoJugando);
        aux = JsonUtility.FromJson<DatosGuardado>(contenido);

        if (aux.vidaJugador.Equals("")) 
        {
            aux.vidaJugador = "0";
        }
        if (aux.DanoJugador.Equals(""))
        {
            aux.DanoJugador = "0";
        }

        if (float.Parse(aux.vidaJugador)<float.Parse(vida)) 
        {
            aux.vidaJugador = vida;
            
        }
        if (float.Parse(aux.DanoJugador) < float.Parse(dano)) 
        {
            aux.DanoJugador = dano;
        }
            aux.boss = boss;
        string cadenaJson = JsonUtility.ToJson(aux, true);
        File.WriteAllText(ArchivoJugando, cadenaJson);
        Debug.Log("Guadar los datos");
    }
    public void textocorreo(string text)
    {
        apodoAux1 = text;
    }

    public void textApodo(string text) 
    {
        apodoAux = text;
    }

    public void textocontrasena(string text)
    {
        contrasenaaux = text;
    }
    public void GetAllApodos()
    {
        comunicado.text = "";
        if (File.Exists(Archivo))
        {
            string contenido2 = "";
            string contenido = File.ReadAllText(Archivo);
            aux = JsonUtility.FromJson<DatosGuardado>(contenido);
            JugadorG = aux.apodo.Split(',');
            for (int i = 0; i < JugadorG.Length; i++)
            {
                if (JugadorG[i] != "") 
                {
                    ArchivoJugando = Application.dataPath + "/" + JugadorG[i] + ".json";
                    contenido = File.ReadAllText(ArchivoJugando);
                    aux = JsonUtility.FromJson<DatosGuardado>(contenido);
                    contenido2 += "Apodo:" + JugadorG[i] + " Vida: " + aux.vidaJugador + " Fuerza: " + aux.DanoJugador + " " + aux.boss + "\n" ;
                }
                
            }
            comunicado.text = contenido2;
        }
        else 
        {
            comunicado.text = "No hay jugadores Resgistrados";
        }
        
    }
}
