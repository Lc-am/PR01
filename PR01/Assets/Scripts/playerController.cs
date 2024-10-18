using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  
    public float fuerzaSalto = 7f;  
    public Rigidbody rb;
    private bool enSuelo = true;

    private Animator animator;
    public bool puedoSaltar;


    void Start()
    {
        puedoSaltar = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

        if(puedoSaltar)
        {
            // Verificar si se presiona la barra espaciadora para saltar
            if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
            {
                animator.SetBool("Saltar", true);
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                enSuelo = false;  // Desactivar la habilidad de saltar hasta que toque el suelo
            }
            animator.SetBool("TocarSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
        
    }

    public void EstoyCayendo()
    {
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Saltar", false);
    }

    // Detectar si el cilindro está tocando el suelo para permitir saltar de nuevo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
