using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Agregamos esto para poder manejar las escenas

public class GameManager : MonoBehaviour
{
  public GameObject player1, player2, player3, player4;
  public static GameManager Instance { get; private set; }
  public static int ronda = 0;
  public static float tiempoDeSalto;
  private float ultimoSalto;
  public static bool momentoEspecial = false;

  //Puntajes por salto
  Dictionary<string, int> puntajes = new Dictionary<string, int>()
    {
     {"Mal", 10},
     {"Regular", 5},
     {"Bien", -10},
    };

  private void Awake()
  {
    ultimoSalto = Time.deltaTime;
    tiempoDeSalto = ultimoSalto;
    Instance = this;
  }
  void Start()
  {
    //Reseteamos el puntaje y otras cosillas al comienzo del juego
    PlayerPrefs.SetInt("Ronda", 0);
  }

  void Update()
  {
    if (ultimoSalto != tiempoDeSalto)
    {
      ultimoSalto = tiempoDeSalto;
    }
  }
  public int PuntosPorSalto(float tiempo)
  {

    float diferencia = tiempoDeSalto - tiempo;

    Debug.Log("Diferencia:" + diferencia);
    //Si la diferencia entre el momento de salto y cuando el jugador salta es menor 1ms le sumamos 1
    if (diferencia <= 0.002f)
    {
      return puntajes["Bien"];
    }

    if (diferencia > 0.002f && diferencia <= 0.003f)
    {
      return puntajes["Regular"];
    }

    return puntajes["Mal"];
  }



  void FinalDeRonda()
  {
    SceneManager.LoadScene("EscenaFinal");
  }
  public void mostrarVapor()
  {
    player1.transform.GetChild(2).gameObject.SetActive(true);
    player2.transform.GetChild(2).gameObject.SetActive(true);
    player3.transform.GetChild(2).gameObject.SetActive(true);
    player4.transform.GetChild(2).gameObject.SetActive(true);
  }

  public bool ocultarVapor(){
    Animator vapor1 = player1.transform.GetChild(2).gameObject.GetComponent<Animator>();
    if (vapor1.GetCurrentAnimatorStateInfo(0).length > vapor1.GetCurrentAnimatorStateInfo(0).normalizedTime){
      player1.transform.GetChild(2).gameObject.SetActive(false);
      player2.transform.GetChild(2).gameObject.SetActive(false);
      player3.transform.GetChild(2).gameObject.SetActive(false);
      player4.transform.GetChild(2).gameObject.SetActive(false);
      return true;
    } else {
      return false;
    }
  }
}