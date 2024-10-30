using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public Rigidbody rb;
    private Animator animator; 

    public bool isGrounded;

    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Saltar", true); // animación del salto
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
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
        // se desactivan las animaciones
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Saltar", false);
    }
}


