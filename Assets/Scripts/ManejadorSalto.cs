using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorSalto : MonoBehaviour
{
  GameManager gm;
  public Animator vapor;
  public GameObject mensajeSaltar;
  public ParticleSystem avisoSalto;

   GameObject textoSalto;
  void Start() {
    gm  = GameObject.Find("GameManager").GetComponent<GameManager>();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    GameManager.tiempoDeSalto = Time.deltaTime;
    mensajeSaltar.SetActive(false);
    avisoSalto.GetComponent<ParticleSystem>().Stop();
    gm.mostrarVapor();
  }

  void Update () {
    if (gm.ocultarVapor())
    {
      avisoSalto.GetComponent<ParticleSystem>().Play();
    }
  }
}
