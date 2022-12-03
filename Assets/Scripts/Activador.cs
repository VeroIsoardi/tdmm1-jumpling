using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour {

    SpriteRenderer sr;

    //Creamos una variable gameObject para poder llamar a gameManager
    GameObject gm;

  //Es lo primero en inicializarse, aunque el script este desactivado
  void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    //Se inicializa luego de awake, solo si el script esta activado
    void Start () {
        //Llamamos a nuestro Game Manager, para poder usar sus funciones
        gm = GameObject.Find("GameManager");

        Component[] jugadores;

        jugadores = GetComponents(typeof(Personaje));
        int i = 0;

        foreach (Personaje personaje in jugadores)
        {
            i++;
        }
  }
	
	// Update is called once per frame
	void Update () {
    }
}

