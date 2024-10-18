using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  
    public float fuerzaSalto = 7f;  
    private Rigidbody rb;
    private bool enSuelo = true;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

        // Verificar si se presiona la barra espaciadora para saltar
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;  // Desactivar la habilidad de saltar hasta que toque el suelo
        }
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
