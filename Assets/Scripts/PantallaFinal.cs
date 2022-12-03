using System.Collections;
using UnityEngine.SceneManagement; //Agregamos esto para poder manejar las escenas
using System.Collections.Generic;
using UnityEngine;

public class PantallaFinal : MonoBehaviour
{
    float timeLeft;
    int ronda;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 5.0f;
  }

  // Update is called once per frame
  void Update()
  {
    ronda = GameManager.ronda;
    Debug.Log(ronda);
    if (timeLeft > 0)
    {
      timeLeft -= Time.deltaTime;
    }
    else
    {
      GameManager.ronda = 0;
      SceneManager.LoadScene("EscenaInicio");
    }
  }
} 