using UnityEngine.SceneManagement; //Agregamos esto para manejar escenas (pasar de pantalla en pantalla => ganaste-perdiste)
using UnityEngine;
using TMPro; 
public class Timer : MonoBehaviour
{
  private float timeLimit = 60.0f;
  public float timeLeft;
  private bool timerIsRunning = false;

  private GameObject timer;

  public TMP_Text timerText;


  private void Start()
  {
    timer = GameObject.Find("timer");
    // Starts the timer automatically
    timerIsRunning = true;
    timeLeft = timeLimit;
  }

  void Update()
  {
    if (timerIsRunning)
    {
      if (timeLeft > 1)
      {
        // if (Mathf.FloorToInt(timeLeft) == 15) {
        //   GameManager.momentoEspecial = true;
        // }

        timeLeft -= Time.deltaTime;
        float seconds = Mathf.FloorToInt(timeLeft%60);
        timerText.text = seconds.ToString ();
      }
      else
      {
        timeLeft = 0;
        timerIsRunning = false;
        SceneManager.LoadScene("EscenaFinal");
      }
    }
  }
}