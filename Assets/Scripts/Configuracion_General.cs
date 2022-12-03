using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Agregamos esto para manejar escenas (pasar de pantalla en pantalla => ganaste-perdiste)
using UnityEngine.UI; //Agregamos esto para manejar las propiedades UI (Canvas, Text, Image, etc).
using TMPro; //Agregamos esto para utilizar las tipografias mas avanzadas.

public class Configuracion_General : MonoBehaviour
{
   // [Header("Configuracion de variables generales")]
  public enum TiposDeJuego { Runner, Shooter, Sincro };
  public TiposDeJuego tipoDeJuego = TiposDeJuego.Sincro;
  public float puntaje = 0f;
  public float tiempo;
  public const float TIEMPOMAXRONDA = 60f;
  static public int cantPlayers = 4;
  public int cantPlayersConfirmados = 0;
  public float velocidadSalto;

  [Header("Configuracion de elementos UI")]
  [SerializeField] private TMP_Text scoreText; //Variable del texto que se visualizara en pantalla en el videojuego. La definimos como publica para poder arrastrar el objeto Text desde el Inspector

  [Header("Configuracion de Escenas")]
  public const int ESCENAINICIO = 1;
  public const int ESCENAJUEGO  = 2;
  public const int ESCENAFINAL  = 3;
  public int escenaActual = 1;

  void Awake() {
  }

  // Start is called before the first frame update
  void Start(){
  }

  // Update is called once per frame
  void Update()
  {

   switch (escenaActual)
    {
      case ESCENAINICIO:
        print("Inicio del juego, confirmar jugadores");
        SceneManager.LoadScene("EscenaInicio");
        break;
      case ESCENAJUEGO:
        print ("Comienza el juego!");
        SceneManager.LoadScene("EscenaJuego");
        break;
      case ESCENAFINAL:
        print ("Finaliza la ronda");
        SceneManager.LoadScene("EscenaFinal");
        break;
    }
  }

}