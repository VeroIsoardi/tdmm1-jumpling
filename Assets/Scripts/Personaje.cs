using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Agregamos esto para manejar escenas (pasar de pantalla en pantalla => ganaste-perdiste)

public class Personaje : MonoBehaviour
{
  public KeyCode tecla;
  public int numeroPersonaje;
  private bool confirmado;
  private GameObject vaporera, originalGameObject, dumpling;
  

  void Start(){
    originalGameObject = GameObject.Find($"StartPlayer ({numeroPersonaje})");
    vaporera   = originalGameObject.transform.GetChild(0).gameObject;
    dumpling   = originalGameObject.transform.GetChild(1).gameObject;
    confirmado = false;
    PlayerPrefs.SetInt("CantidadJugadoresConfirmados", 0);
  }

  void Update()
  {
    if (!confirmado) {
      if(!Input.GetKey(tecla))
      {
        print ("Esperando que confirme el jugador");
      } else {
        confirmado = true;
        print ($"Jugador {numeroPersonaje} confirmado");
        vaporera.SetActive(false);
        dumpling.SetActive(true);
        PlayerPrefs.SetInt($"Jugador#{numeroPersonaje}", 1);
        if (cantidadJugadoresListos(numeroPersonaje) == 4) {
          print ("Cargando escena de juego");
          SceneManager.LoadScene("EscenaJuego");
        }
      }
    }
  }

  private int cantidadJugadoresListos(int numeroJugador){
    int cant = PlayerPrefs.GetInt("CantidadJugadoresConfirmados");
    switch (numeroJugador) {
      case 1:
        if(PlayerPrefs.GetInt("Jugador#1") == 1)
          cant++;
        break;
      case 2:
        if(PlayerPrefs.GetInt("Jugador#2") == 1)
          cant++;
        break;
      case 3:
        if(PlayerPrefs.GetInt("Jugador#3") == 1)
          cant++;
        break;
      case 4:
        if(PlayerPrefs.GetInt("Jugador#4") == 1)
          cant++;
        break;
    }
    print(cant);
    PlayerPrefs.SetInt("CantidadJugadoresConfirmados", cant);
    return cant;
  }
}
