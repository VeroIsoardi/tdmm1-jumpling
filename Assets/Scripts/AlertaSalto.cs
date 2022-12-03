using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertaSalto : MonoBehaviour
{
  public GameObject mensajeSaltar;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("entroo");
    mensajeSaltar.SetActive(true);
  }
}
