using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoDump : MonoBehaviour
{
    public KeyCode tecla;
    private Rigidbody2D rb2D;
    private Vector3 velocidad = Vector3.zero;
    [Header("Salto")]
    [SerializeField] private float FuerzaSalto;
    [SerializeField] float Salto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    GameManager gm;

    private bool salto = false;
    private int vidaTotal, vidaPerdidaEnElSalto;
    private float tiempoDeSalto, tiempoLabels;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        vidaTotal = 100;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

    private void Update()
    {
        if (Input.GetKeyUp(tecla))
        {
            salto = true;
            tiempoDeSalto = Time.deltaTime;
            vidaPerdidaEnElSalto = gm.PuntosPorSalto(tiempoDeSalto);
            vidaTotal -= vidaPerdidaEnElSalto;
            animator.SetInteger("Vida", vidaTotal);
        } else {
            salto = false;
        }
    }

    private void FixedUpdate(){
        animator.SetBool("enSuelo", enSuelo);
        Saltar();
        //mover
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
        salto = false;
    }
    
    private void Saltar()
    {
        if (enSuelo && salto)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0, FuerzaSalto));
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}